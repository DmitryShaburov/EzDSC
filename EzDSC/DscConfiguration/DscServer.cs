using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace EzDSC
{
    public class DscServer
    {
        public List<string> Roles;
        public Dictionary<string, string> Variables;

        public DscServer()
        {
            Roles = new List<string>();
            Variables = new Dictionary<string, string>();
        }

        public void Save(string path)
        {
            File.WriteAllText(path, new JavaScriptSerializer().Serialize(this));
        }

        public static DscServer Load(string path)
        {
            return new JavaScriptSerializer().Deserialize<DscServer>(File.ReadAllText(path));
        }
    }
}
