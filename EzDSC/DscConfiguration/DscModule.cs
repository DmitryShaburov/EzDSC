using System;
using System.Collections.Generic;
using System.IO;

namespace EzDSC
{
    public class DscModule
    {
        public string Name;
        public string DirectoryPath;
        public Guid Id;
        public string Author;
        public string CompanyName;
        public string Copyright;
        public bool Default;
        public List<DscResource> Resources = new List<DscResource>();

        public DscModule(string path)
        {
            DirectoryPath = path;
            Name = Path.GetFileName(path);
            string[] resources = Directory.GetDirectories(path + "\\DSCResources\\");
            foreach (string resource in resources)
            {
                string[] schema = Directory.GetFiles(resource, "*.schema.mof");
                if (schema.Length > 0)
                {
                    Resources.Add(new DscResource(schema[0], this));
                }
            }
        }
    }
}
