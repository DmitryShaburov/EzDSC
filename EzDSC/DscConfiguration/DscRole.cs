using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace EzDSC
{
    public class DscRole
    {
        public List<string> Resources;

        public DscRole()
        {
            Resources = new List<string>();
        }

        public static DscRole Load(string path)
        {
            return new JavaScriptSerializer().Deserialize<DscRole>(File.ReadAllText(path));
        }

        public void Save(string path)
        {
            File.WriteAllText(path, new JavaScriptSerializer().Serialize(this));
        }
    }
}
