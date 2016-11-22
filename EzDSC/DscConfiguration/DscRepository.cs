using System;
using System.Collections.Generic;
using System.IO;

namespace EzDSC
{
    public class DscRepository
    {
        public DscRepositoryFolders Dir;
        public List<DscModule> Modules = new List<DscModule>();
        public DscRoleGroup Roles;
        public DscServerNode Servers;

        public DscRepository(string path)
        {
            Dir = new DscRepositoryFolders(path);
            LoadModules(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\WindowsPowerShell\\v1.0\\Modules\\");
            LoadModules(Dir.Modules);
            LoadConfigurationItems();
            Roles = new DscRoleGroup(Dir.Roles, null);
            Servers = new DscServerNode(DscServerNode.ServerType.Root, Dir.Servers + ".group", null);
        }

        public void LoadModules(string path)
        {
            string[] modules = Directory.GetDirectories(path);
            foreach (string module in modules)
            {
                if (!Directory.Exists(module + "\\DSCResources\\")) continue;
                Modules.Add(new DscModule(module));
            }
        }

        public void LoadConfigurationItems()
        {
            foreach (DscModule module in Modules)
            {
                foreach (DscResource resource in module.Resources)
                {
                    string path = Dir.Resources + module.Name + "\\" + resource.FriendlyName;
                    Dir.DirectoryCreateIfNotExists(path);
                    string[] configurationItems = Directory.GetFiles(path, "*.json");
                    foreach (string configurationItem in configurationItems)
                    {
                        resource.Nodes.Add(new DscConfigurationItemNode(configurationItem, resource));
                    }
                }
            }
        }

        public DscConfigurationItemNode GetConfigurationItemNode(string fullname)
        {
            string[] path = fullname.Split('.');
            DscModule module = Modules.Find(x => x.Name == path[0]);
            DscResource resource = module.Resources.Find(x => x.FriendlyName == path[1]);
            return resource.Nodes.Find(x => x.Name == path[2]);
        }
    }
}
