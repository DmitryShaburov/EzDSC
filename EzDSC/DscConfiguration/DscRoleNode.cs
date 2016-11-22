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
            Name = Path.GetFileName(path).Replace(".json", "");
            Role = DscRole.Load(path);
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
    }
}
