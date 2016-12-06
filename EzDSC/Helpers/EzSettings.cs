using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EzDSC
{
    public class EzSettings
    {
        public string LastRepositoryPath;
        public FormWindowState WindowState = FormWindowState.Normal;
        public Size WindowSize = new Size(1200, 600);

        public static string GetPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EzDSC\\settings.json";
        }

        public static EzSettings Load()
        {
            string path = GetPath();
            FileSystem.DirectoryCreateIfNotExists(Path.GetDirectoryName(path));
            return !File.Exists(path) ? new EzSettings() : JsonConvert.DeserializeObject<EzSettings>(File.ReadAllText(path));
        }

        public void Save()
        {
            File.WriteAllText(GetPath(), JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
