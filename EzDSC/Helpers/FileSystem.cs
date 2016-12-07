using System;
using System.IO;

namespace EzDSC
{
    class FileSystem
    {
        public static void DirectoryCopy(string source, string destination)
        {
            DirectoryInfo dir = new DirectoryInfo(source);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + source);
            }

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destination, file.Name);
                file.CopyTo(temppath, false);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destination, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath);
            }
        }

        public static void DirectoryCreateIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string GetTempFile()
        {
            return Path.GetTempPath() + Guid.NewGuid() + ".ps1";
        }
    }
}
