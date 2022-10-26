using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGuidGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guid token = Guid.NewGuid();
            string command = $"C:\\Users\\raven\\source\\repos\\CustomLoginCore\\CustomLoginCore>dotnet user-secrets set \"Token:\" \"{token}\"";

            string cdCommand = "cd C:\\Users\\raven\\source\\repos\\CustomLoginCore\\CustomLoginCore";
            string setCommand = $"dotnet user-secrets set \"Token:\" \"{token}\"";

            RunCommand(cdCommand, setCommand);
        }

        public static void RunCommand(string cdCommand, string setCommand)
        {
            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();

            /* execute "dir" */

            cmd.StandardInput.WriteLine(cdCommand);
            cmd.StandardInput.WriteLine(setCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }
    }
}
