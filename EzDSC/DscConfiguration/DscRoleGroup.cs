using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EzDSC
{
    public class DscRoleGroup
    {
        public string DirectoryPath;
        public string Name;
        public DscRoleGroup Parent;
        public List<DscRoleNode> Nodes = new List<DscRoleNode>();
        public List<DscRoleGroup> Groups = new List<DscRoleGroup>();

        public DscRoleGroup(string path, DscRoleGroup parent)
        {
            DirectoryPath = path;
            Name = Path.GetFileName(Path.GetDirectoryName(path));
            Parent = parent;
            string[] roles = Directory.GetFiles(path, "*.json");
            string[] groups = Directory.GetDirectories(path);
            foreach (string role in roles)
            {
                Nodes.Add(new DscRoleNode(role, this));
            }
            foreach (string group in groups)
            {
                Groups.Add(new DscRoleGroup(group, this));
            }
        }

        public string BuildName()
        {
            string fullname = Name;
            if (Parent != null)
            {
                fullname = Parent.BuildName() + "." + fullname;
            }
            return fullname;
        }

        public DscRoleNode GetRoleNode(string fullname)
        {
            string[] path = fullname.Split('.');
            if (path.Length == 2)
            {
                return Nodes.Find(x => x.Name == path[1]);
            }
            DscRoleGroup nextGroup = Groups.Find(x => x.Name == path[1]);
            return nextGroup.GetRoleNode(string.Join(".", path.Skip(1).ToArray()));
        }
    }
}
