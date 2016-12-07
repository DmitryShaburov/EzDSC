using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EzDSC
{
    class PsCodeBuilder
    {
        private static List<string> GetConfigData(PsConfiguration configuration)
        {
            List<string> configData = new List<string>
            {
                "$ConfigData_" + configuration.GetId() + " = @{",
                "AllNodes = @(",
                "@{",
                "NodeName = '*'",
                "PSDscAllowDomainUser = $true",
                "PSDscAllowPlainTextPassword = $true",
                "}"
            };
            foreach (string server in configuration.Servers)
            {
                configData.AddRange(new List<string>
                {
                    ",@{",
                    "NodeName = '" + server + "'",
                    "}"
                });
            }
            configData.AddRange(new List<string>
                {
                    ")",
                    "}"
                });

            return configData;
        }

        private static List<string> GetConfigurationItemText(DscConfigurationItemNode node, DscRepository repository)
        {
            List<string> itemText = new List<string> {node.Parent.FriendlyName + " \"" + node.Name + "\"", "{"};

            foreach (DictionaryEntry entry in node.ConfigurationItem.Properties)
            {
                if ((entry.Value == null) || (entry.Value.ToString() == "")) continue;
                switch (node.Parent.GetVariableTypeOf(entry.Key.ToString()))
                {
                    case DscResource.VariableType.String:
                        if (entry.Value.ToString().StartsWith("$") || entry.Value.ToString().StartsWith("\""))
                        {
                            itemText.Add(entry.Key + " = " + entry.Value);
                        }
                        else
                        {
                            itemText.Add(entry.Key + " = \"" + entry.Value + "\"");
                        }
                        break;

                    case DscResource.VariableType.Boolean:
                        itemText.Add(entry.Key + " = $" + entry.Value);
                        break;
                    case DscResource.VariableType.Uint16:
                    case DscResource.VariableType.Sint16:
                    case DscResource.VariableType.Uint32:
                    case DscResource.VariableType.Sint32:
                    case DscResource.VariableType.Uint64:
                    case DscResource.VariableType.Sint64:
                        itemText.Add(entry.Key + " = " + entry.Value);
                        break;

                    default:
                        itemText.Add(entry.Key + " = \"" + entry.Value + "\"");
                        break;
                }
            }
            if (node.ConfigurationItem.DependsOn.Count > 0)
            {
                List<string> dependsOn = new List<string>();
                foreach (string dependency in node.ConfigurationItem.DependsOn)
                {
                    DscConfigurationItemNode dependencyNode = repository.GetConfigurationItemNode(dependency);
                    dependsOn.Add("'[" + dependencyNode.Parent.FriendlyName + "]" + dependencyNode.Name + "'");
                }
                itemText.Add("DependsOn = " + string.Join(",", dependsOn));
            }
            itemText.Add("}");

            return itemText;
        }

        private static List<string> GetConfigText(PsConfiguration configuration, DscRepository repository)
        {
            List<string> configText = new List<string> { "Configuration Config_" + configuration.GetId(), "{", "Param", "(" };

            for (int i = 0; i < configuration.Variables.Keys.Count; i++)
            {
                if (i == configuration.Variables.Keys.Count - 1)
                {
                    configText.Add("$" + configuration.Variables.Keys.ElementAt(i));
                }
                else
                {
                    configText.Add("$" + configuration.Variables.Keys.ElementAt(i) + ",");
                }
            }
            configText.Add(")");
            configText.AddRange(configuration.GetUsedModules(repository).Select(module => "Import-DscResource -Module " + module));
            configText.AddRange(new List<string> {"Node $AllNodes.Nodename", "{" });
            HashSet<string> resourceStrings = new HashSet<string>();
            foreach (string roleString in configuration.Roles)
            {
                DscRoleNode roleNode = repository.Roles.GetRoleNode(roleString);
                resourceStrings.UnionWith(roleNode.Role.Resources);
            }
            foreach (string resourceString in resourceStrings)
            {
                DscConfigurationItemNode configurationItemNode = repository.GetConfigurationItemNode(resourceString);
                configText.AddRange(GetConfigurationItemText(configurationItemNode, repository));
            }
            configText.AddRange(new List<string> { "}", "}" });
            return configText;
        }

        private static string Tabs(int n)
        {
            return new string('\t', n);
        }

        private static bool ContainsOpening(string line)
        {
            return (line.Contains("{") && !line.Contains("}")) || (line.Contains("(") && !line.Contains(")"));
        }

        private static bool ContainsClosing(string line)
        {
            return (line.Contains("}") && !line.Contains("{")) || (line.Contains(")") && !line.Contains("("));
        }

        private static List<string> Tabulate(List<string> script)
        {
            List<string> result = new List<string>();
            int tabs = 0;
            foreach (string line in script)
            {
                if (ContainsClosing(line))
                {
                    tabs--;
                }
                result.Add(Tabs(tabs) + line);
                if (ContainsOpening(line))
                {
                    tabs++;
                }
            }
            return result;
        }

        public static List<string> BuildScript(List<PsConfiguration> configurations, DscRepository repository)
        {
            List<string> script = new List<string>();
            foreach (PsConfiguration configuration in configurations)
            {
                script.AddRange(GetConfigData(configuration));
                script.AddRange(configuration.Variables.Select(variable => "$" + variable.Key + "_" + configuration.GetId() + " = " + variable.Value));
            }
            foreach (PsConfiguration configuration in configurations)
            {
                script.AddRange(GetConfigText(configuration, repository));
            }
            foreach (PsConfiguration configuration in configurations)
            {
                string varParameters = configuration.Variables.Aggregate("",
                    (current, variable) =>
                        current +
                        (" -" + variable.Key + " $" + variable.Key + "_" + configuration.GetId()));

                script.Add("Config_" + configuration.GetId() + " -ConfigurationData $ConfigData_" + configuration.GetId() + varParameters);
                script.Add("Start-DscConfiguration -Path Config_" + configuration.GetId() + " -force -wait -verbose");
            }
            script.Add("Write-Host 'Press any key to continue ...'");
            script.Add("$x = $host.UI.RawUI.ReadKey(\"NoEcho, IncludeKeyDown\")");
            return Tabulate(script);
        }

        public static List<string> BuildUnblockFile(List<string> files)
        {
            List<string> script = files.Select(file => "Unblock-File -Path \"" + file + "\"").ToList();
            return Tabulate(script);
        }
    }
}
