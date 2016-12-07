using System.Collections.Generic;
using System.IO;

namespace EzDSC
{
    public class DscRoleNode
    {
        public string FilePath;
        public string Name;
        public DscRole Role;
        public DscRoleGroup Parent;

        public DscRoleNode(string path, DscRoleGroup parent)
        {
            Parent = parent;
            FilePath = path;
            string fileName = Path.GetFileName(path);
            if (fileName != null) Name = fileName.Replace(".json", "");
            Role = DscRole.Load(path);
        }

        public string BuildName()
        {
            string fullname = Name;
            if (Parent != null)
            {
                fullname = Parent.BuildName() + ":" + fullname;
            }
            return fullname;
        }

        public HashSet<string> FindUsages(DscServerNode serverNode)
        {
            HashSet<string> usages = new HashSet<string>();
            string fullname = BuildName();
            if (serverNode.Node.Roles.Contains(fullname))
            {
                usages.Add(serverNode.Name);
            }
            foreach (DscServerNode childNode in serverNode.Nodes)
            {
                usages.UnionWith(FindUsages(childNode));
            }
            return usages;
        }
    }
}
