using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
            return JsonConvert.DeserializeObject<DscRole>(File.ReadAllText(path));
        }

        public void Save(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
