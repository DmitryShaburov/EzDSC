using System;
using System.IO;

namespace EzDSC
{
    public class DscRepositoryFolders
    {
        // Repository-specific paths
        public string Root;
        public string Roles;
        public string Servers;
        public string Modules;
        public string Resources;
        public string Output;
        // Application-specific paths
        public string AppRoot;
        public string AppModules;

        public void InitRootServer()
        {
            string filename = Servers + ".group";
            if (!File.Exists(filename))
            {
                DscServer root = new DscServer();
                root.Save(filename);
            }
        }

        public DscRepositoryFolders(string path)
        {
            Root = path + "\\";
            Roles = Root + "Roles\\";
            Servers = Root + "Servers\\";
            Modules = Root + "Modules\\";
            Resources = Root + "Resources\\";
            Output = Root + "Output\\";

            FileSystem.DirectoryCreateIfNotExists(Root);
            FileSystem.DirectoryCreateIfNotExists(Roles);
            FileSystem.DirectoryCreateIfNotExists(Modules);
            FileSystem.DirectoryCreateIfNotExists(Servers);
            FileSystem.DirectoryCreateIfNotExists(Resources);
            FileSystem.DirectoryCreateIfNotExists(Output);

            AppRoot = AppDomain.CurrentDomain.BaseDirectory;
            AppModules = AppRoot + "Modules\\";

            InitRootServer();
        }
    }
}
