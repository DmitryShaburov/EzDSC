using System;
using System.Collections.Generic;
using System.Linq;

namespace EzDSC
{
    public class PsConfiguration
    {
        public Guid Id;
        public HashSet<string> Servers;
        public HashSet<string> Roles;
        public Dictionary<string, string> Variables;

        public string GetId()
        {
            return Id.ToString("N").ToUpper();
        }

        public HashSet<string> GetUsedModules(DscRepository repository)
        {
            HashSet<string> modules = new HashSet<string>();
            HashSet<string> resourceStrings = new HashSet<string>();
            foreach (string roleString in Roles)
            {
                DscRoleNode roleNode = repository.Roles.GetRoleNode(roleString);
                resourceStrings.UnionWith(roleNode.Role.Resources);
            }
            foreach (string resourceString in resourceStrings)
            {
                DscConfigurationItemNode configurationItemNode = repository.GetConfigurationItemNode(resourceString);
                if (configurationItemNode.Parent.Parent.Name != "PSDesiredStateConfiguration")
                {
                    modules.Add(configurationItemNode.Parent.Parent.Name);
                }
            }
            return modules;
        }

        public PsConfiguration(string server, HashSet<string> roles, Dictionary<string, string> variables)
        {
            Id = Guid.NewGuid();
            Servers = new HashSet<string> {server};
            Roles = roles;
            Variables = variables;
        }

        public bool IsEqual(PsConfiguration configuration)
        {
            bool rolesEqual = Roles.SetEquals(configuration.Roles);
            bool variablesEqual = (Variables.Count == configuration.Variables.Count &&
                                   !Variables.Except(configuration.Variables).Any());
            return (rolesEqual && variablesEqual);
        }

        public static PsConfiguration FindEqual(List<PsConfiguration> list, PsConfiguration configuration)
        {
            foreach (PsConfiguration listConfiguration in list)
            {
                if (listConfiguration.IsEqual(configuration))
                {
                    return listConfiguration;
                }
            }
            return null;
        }
    }
}
