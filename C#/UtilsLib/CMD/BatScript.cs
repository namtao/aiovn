using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsLib.CMD
{
    class BatScript
    {
        public void runCmd(string cmd)
        {
            Process process = new Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.Arguments = "/user:Administrator \"cmd /K " + cmd + "\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Verb = "runas";
            process.Start();
            //System.IO.StreamReader SR = process.StandardOutput;
            //System.IO.StreamWriter SW = process.StandardInput;
            process.StandardInput.WriteLine("ipconfig");
            //SW.WriteLine("ipconfig");
            process.StandardInput.Flush();
            process.StandardInput.Close();
        }
    }
}
