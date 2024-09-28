using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Homework_SysPr_1
{
    class ApplicationContext : DbContext
    {
        
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }

    public class Program
    {
        static void Main()
        {
            string childProcessPath = "system32\\notepad.exe";
            Process childProcess = new Process();
            childProcess.StartInfo.FileName = childProcessPath;
            childProcess.StartInfo.UseShellExecute = false;
            childProcess.StartInfo.RedirectStandardOutput = true;
            childProcess.StartInfo.RedirectStandardError = true;
            childProcess.StartInfo.CreateNoWindow = true;
            childProcess.EnableRaisingEvents = true;
            childProcess.Exited += (sender, EventArgs) =>
            {
                int exitCode = childProcess.ExitCode;
                Console.WriteLine($"Дочерний процесс завершился с кодом {exitCode}");
                childProcess.Dispose();
            };

            childProcess.Start();
            childProcess.WaitForExit();
        }
    }
}
