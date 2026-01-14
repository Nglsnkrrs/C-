using System;
using System.Diagnostics;

namespace Task_1
{
    class Parent
    {
        public static void Run()
        {
            Process process = new Process();

            process.StartInfo.FileName =
                Process.GetCurrentProcess().MainModule.FileName;

            process.StartInfo.Arguments = "child";
            process.StartInfo.UseShellExecute = false;

            process.Start();
            process.WaitForExit();

            Console.WriteLine("Код завершения дочернего процесса: " +
                              process.ExitCode);

            Console.ReadLine();
        }
    }
}
