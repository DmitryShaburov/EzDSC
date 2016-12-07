using System.Collections.Generic;
using System.IO;

namespace EzDSC
{
    public class DscConfigurationItemNode
    {
        public string Name;
        public string FilePath;
        public DscResource Parent;
        public DscConfigurationItem ConfigurationItem;

        public DscConfigurationItemNode(string path, DscResource parent)
        {
            FilePath = path;
            Parent = parent;

            string fileName = Path.GetFileName(path);
            if (fileName != null) Name = fileName.Replace(".json", "");

            ConfigurationItem = DscConfigurationItem.Load(path);
        }

        public string GetFullName()
        {
            return Parent.Parent.Name + ":" + Parent.FriendlyName + ":" + Name;
        }

        public void Validate()
        {
            foreach (DscResource.Parameter parameter in Parent.Parameters)
            {
                if (parameter.Qualifier != DscResource.QualifierType.Required) continue;
                if (ConfigurationItem.Properties[parameter.Name] == null ||
                    ConfigurationItem.Properties[parameter.Name].ToString() == "")
                {
                    ConfigurationItem.Properties[parameter.Name] = parameter.GetDefaultValue();
                }
            }
        }

        public HashSet<string> FindUsages(DscRoleGroup group)
        {
            HashSet<string> usages = new HashSet<string>();
            foreach (DscRoleNode node in group.Nodes)
            {
                if (node.Role.Resources.Contains(GetFullName()))
                {
                    usages.Add(node.BuildName());
                }
            }
            foreach (DscRoleGroup child in group.Groups)
            {
                usages.UnionWith(FindUsages(child));
            }
            return usages;
        }
    }
}
