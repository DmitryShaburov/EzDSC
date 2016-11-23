using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EzDSC
{
    public class EzSettings
    {
        public string LastRepositoryPath;
        public FormWindowState WindowState;
        public Size WindowSize;

        public static EzSettings Load(string path)
        {
            return JsonConvert.DeserializeObject<EzSettings>(File.ReadAllText(path));
        }

        public void Save(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
