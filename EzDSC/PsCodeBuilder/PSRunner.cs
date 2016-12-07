using System.Diagnostics;

namespace EzDSC
{
    public static class PsRunner
    {
        public static void Start(string filename)
        {
            Process.Start("powershell.exe", "-ExecutionPolicy Unrestricted -File " + filename);
        }
    }
}
