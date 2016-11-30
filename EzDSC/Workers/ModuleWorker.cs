using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzDSC;
using System.IO;

namespace Workers
{
    class ModuleWorker
    {
        public static void InstallModules(DscRepository repository, HashSet<string> servers, HashSet<string> modules)
        {
            foreach (string module in modules)
            {
                if (module == "PSDesiredStateConfiguration") continue;
                foreach (string server in servers)
                {
                    string source = repository.Dir.Modules + module;
                    string destination = "\\\\" + server + "\\C$\\Program Files\\WindowsPowerShell\\Modules\\" + module;
                    if (!Directory.Exists(destination))
                    {
                        FileSystem.DirectoryCopy(source, destination, true);
                    }
                }
            }
        }

        public static void InstallLocalModules(DscRepository repository)
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            repository.Dir.DirectoryCreateIfNotExists(documents + "\\WindowsPowerShell");
            repository.Dir.DirectoryCreateIfNotExists(documents + "\\WindowsPowerShell\\Modules");
            foreach (DscModule module in repository.Modules)
            {
                if (module.Name == "PSDesiredStateConfiguration") continue;
                string destination = documents + "\\WindowsPowerShell\\Modules\\" + module.Name;
                if (!Directory.Exists(destination))
                {
                     FileSystem.DirectoryCopy(module.DirectoryPath, destination, true);
                }
            }
        }
    }
}
