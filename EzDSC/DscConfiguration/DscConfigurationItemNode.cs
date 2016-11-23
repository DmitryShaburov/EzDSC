using System.IO;

namespace EzDSC
{
    public class DscConfigurationItemNode
    {
        public string Name;
        public DscResource Parent;
        public DscConfigurationItem ConfigurationItem;

        public DscConfigurationItemNode(string path, DscResource parent)
        {
            Parent = parent;
            Name = Path.GetFileName(path).Replace(".json", "");
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
    }
}
