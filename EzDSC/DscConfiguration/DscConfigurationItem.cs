using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EzDSC
{
    public class DscConfigurationItem
    {
        public IDictionary Properties = new Hashtable();
        public List<string> DependsOn = new List<string>();

        private string SearchArray(string[] arr, string s)
        {
            foreach (string str in arr)
            {
                if (str.TrimStart().ToLower().StartsWith(s.ToLower()))
                {
                    return str;
                }
            }
            return null;
        }

        public DscConfigurationItem()
        {

        }

        public DscConfigurationItem(DscResource schema)
        {
            foreach (DscResource.Parameter parameter in schema.Parameters)
            {
                if (parameter.Qualifier == DscResource.QualifierType.Read) continue;
                object value = null;
                if (parameter.Type == DscResource.VariableType.String)
                {
                    value = "";
                }
                Properties.Add(parameter.Name, value);
            }
        }

        public static DscConfigurationItem Load(string path)
        {
            return JsonConvert.DeserializeObject<DscConfigurationItem>(File.ReadAllText(path));
        }

        public void Save(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
