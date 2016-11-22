using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EzDSC
{
    public class SchemaMofFile
    {
        public string ClassVersion;
        public string FriendlyName;
        public string ClassName;
        public List<MofParameter> Parameters = new List<MofParameter>();

        public class MofParameter
        {
            public string Qualifier;
            public string Name;
            public string Type;
            public string[] Values = null;
        }


        private static string WildCardToRegular(string value)
        {
            return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
        }

        private static string GetStringInsideOf(string s, char open, char close)
        {
            int start = s.IndexOf(open) + 1;
            int end = s.IndexOf(close, start);
            return s.Substring(start, end - start);
        }

        private static string[] SplitQualifiers(string s)
        {
            List<int> delimiterPositions = new List<int>();
            int bracesDepth = 0;

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '{':
                        bracesDepth++;
                        break;
                    case '}':
                        bracesDepth--;
                        break;
                    default:
                        if (bracesDepth == 0 && s[i] == ',')
                        {
                            delimiterPositions.Add(i);
                        }
                        break;
                }
            }

            List<string> output = new List<string>();

            for (int i = 0; i < delimiterPositions.Count; i++)
            {
                int index = i == 0 ? 0 : delimiterPositions[i - 1] + 1;
                int length = delimiterPositions[i] - index;
                string str = s.Substring(index, length);
                output.Add(str.Trim());
            }

            if (delimiterPositions.Count == 0)
            {
                delimiterPositions.Add(-1);
            }

            string lastString = s.Substring(delimiterPositions.Last() + 1);
            output.Add(lastString);

            return output.ToArray();
        }

        public SchemaMofFile(string path)
        {
            string[] mofFile = File.ReadAllLines(path);
            foreach (string line in mofFile)
            {
                string tempLine = line.Trim();

                // Parsing [ClassVersion("1.0.0"),FriendlyName("Script")] line
                if (Regex.IsMatch(tempLine, WildCardToRegular("[ClassVersion(*)*FriendlyName(*)]")))
                {
                    ClassVersion = tempLine.Split('"', '"')[1];
                    FriendlyName = tempLine.Split('"', '"')[3];
                }

                // Parsing class MSFT_ScriptResource : OMI_BaseResource line
                if (Regex.IsMatch(tempLine, WildCardToRegular("class *:*")))
                {
                    ClassName = tempLine.Split(':')[0].Replace("class ", "").Trim();
                }

                // Parsing parameters lines
                if (!Regex.IsMatch(tempLine, WildCardToRegular("[*] * *;"))) continue;
                MofParameter parameter = new MofParameter();
                string[] qualifierArray = SplitQualifiers(GetStringInsideOf(tempLine, '[', ']'));
                parameter.Qualifier = qualifierArray[0];
                foreach (string q in qualifierArray)
                {
                    if (q.ToLower().StartsWith("values"))
                    {
                        parameter.Values = GetStringInsideOf(q, '{', '}').Split(',').Select(p => p.Trim().Replace("\"", "")).ToArray();
                    }
                }
                int varStart = tempLine.IndexOf(']') + 1;
                string[] s = tempLine.Substring(varStart).Trim().Replace(";", "").Split(' ');
                parameter.Type = s[0];
                parameter.Name = s[1].Replace("[]", "");
                Parameters.Add(parameter);
            }
        }
    }
}
