using System;
using System.Collections.Generic;
using System.IO;

namespace EzDSC
{
    public class DscServerNode
    {
        public enum ServerType
        {
            Root,
            Server,
            Group
        };

        public DscServer Node;
        public DscServerNode Parent;
        public ServerType Type;
        public List<DscServerNode> Nodes;
        public string FilePath;
        public string Name;

        public HashSet<string> GetRoles()
        {
            HashSet<string> roles = new HashSet<string>();
            roles.UnionWith(Node.Roles);
            if (Parent != null)
            {
                roles.UnionWith(Parent.GetRoles());
            }
            return roles;
        }

        public Dictionary<string, string> GetVariables()
        {
            Dictionary<string, string> variables = new Dictionary<string, string>(Node.Variables);
            if (Parent == null) return variables;
            Dictionary<string, string> parentVariables = Parent.GetVariables();
            foreach (KeyValuePair<string, string> variable in parentVariables)
            {
                if (!variables.ContainsKey(variable.Key))
                {
                    variables.Add(variable.Key, variable.Value);
                }
            }
            return variables;
        }

        public List<PsConfiguration> GetConfigurations()
        {
            List<PsConfiguration> tempConfigs = new List<PsConfiguration>();

            if (Type == ServerType.Server)
            {
                tempConfigs.Add(new PsConfiguration(Name, GetRoles(), GetVariables()));
                return tempConfigs;
            }
            foreach (DscServerNode child in Nodes)
            {
                tempConfigs.AddRange(child.GetConfigurations());
            }

            List<PsConfiguration> resultConfigs = new List<PsConfiguration>();
            foreach (PsConfiguration tempConfig in tempConfigs)
            {
                PsConfiguration existingConfiguration = PsConfiguration.FindEqual(resultConfigs, tempConfig);
                if (existingConfiguration != null)
                {
                    existingConfiguration.Servers.UnionWith(tempConfig.Servers);
                }
                else
                {
                    resultConfigs.Add(tempConfig);
                }
            }

            return resultConfigs;
        }

        public DscServerNode (ServerType type, string path, DscServerNode parent)
        {
            Type = type;
            FilePath = path;
            Parent = parent;
            Nodes = new List<DscServerNode>();
            Node = DscServer.Load(FilePath);

            string folder = Path.GetDirectoryName(FilePath);
            if (folder == null) return;

            switch (type)
            {
                case ServerType.Root:
                case ServerType.Group:
                    Name = Path.GetFileName(Path.GetDirectoryName(path));
                    string[] servers = Directory.GetFiles(folder, "*.json");
                    string[] groups = Directory.GetDirectories(folder);
                    foreach (string server in servers)
                    {
                        Nodes.Add(new DscServerNode(ServerType.Server, server, this));
                    }
                    foreach (string group in groups)
                    {
                        Nodes.Add(new DscServerNode(ServerType.Group, group + "\\.group", this));
                    }
                    break;
                case ServerType.Server:
                    string fileName = Path.GetFileName(path);
                    if (fileName != null) Name = fileName.Replace(".json", "");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
