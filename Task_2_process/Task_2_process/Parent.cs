using System;
using System.Diagnostics;

namespace Task_2
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

            Console.WriteLine("1 — ожидать завершения дочернего процесса");
            Console.WriteLine("2 — принудительно завершить дочерний процесс");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                process.WaitForExit();
                Console.WriteLine("Код завершения: " + process.ExitCode);
            }
            else if (choice == "2")
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    Console.WriteLine("Дочерний процесс был принудительно завершён.");
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }

            Console.ReadLine();
        }
    }
}
