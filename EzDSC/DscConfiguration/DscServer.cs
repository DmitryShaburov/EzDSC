using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public static DscServer Load(string path)
        {
            return JsonConvert.DeserializeObject<DscServer>(File.ReadAllText(path));
        }
    }
}
