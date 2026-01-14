using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_process
{
    class Parent
    {
        public static void Run()
        {
            Console.Write("Введите первое число: ");
            string a = Console.ReadLine();

            Console.Write("Введите второе число: ");
            string b = Console.ReadLine();

            Console.Write("Введите операцию (+, -, *, /): ");
            string op = Console.ReadLine();

            Process process = new Process();

            process.StartInfo.FileName =
                Process.GetCurrentProcess().MainModule.FileName;

            process.StartInfo.Arguments = $"child {a} {b} {op}";
            process.StartInfo.UseShellExecute = false;

            process.Start();
            process.WaitForExit();

            Console.ReadLine();
        }
    }
}
