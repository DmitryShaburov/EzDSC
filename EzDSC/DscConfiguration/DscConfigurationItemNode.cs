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
    }
}
