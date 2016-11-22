using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace EzDSC
{
    public class DscConfigurationItem
    {
        public IDictionary Properties = new Hashtable();

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
            return new JavaScriptSerializer().Deserialize<DscConfigurationItem>(File.ReadAllText(path));
        }

        public void Save(string path)
        {
            File.WriteAllText(path, new JavaScriptSerializer().Serialize(this));
        }

        public List<string> GetPSCode()
        {
            List<string> lines = new List<string>();

            //lines.Add(Type + " " + Name);
            //lines.Add("{");
            //foreach (DictionaryEntry entry in Properties)
            //{
            //    if ((entry.Value == null) || (entry.Value.ToString() == "")) continue;
            //    switch (Schema.GetVariableTypeOf(entry.Key.ToString()))
            //    {
            //        case Mof.VariableType.vtString:
            //            lines.Add(entry.Key.ToString() + " = \"" + entry.Value.ToString() + "\"");
            //            break;

            //        case Mof.VariableType.vtBoolean:
            //            lines.Add(entry.Key.ToString() + " = $" + entry.Value.ToString());
            //            break;

            //        case Mof.VariableType.vtUINT32:
            //        case Mof.VariableType.vtUINT64:
            //        case Mof.VariableType.vtSINT32:
            //        case Mof.VariableType.vtSINT64:
            //            lines.Add(entry.Key.ToString() + " = " + entry.Value.ToString());
            //            break;

            //        default:
            //            lines.Add(entry.Key.ToString() + " = \"" + entry.Value.ToString() + "\"");
            //            break;
            //    }
            //}
            //lines.Add("}");

            return lines;
        }
    }
}
