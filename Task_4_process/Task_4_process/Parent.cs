using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_process
{
    class Parent
    {
        public static void Run()
        {
            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();

            Console.Write("Введите слово для поиска: ");
            string word = Console.ReadLine();

            Process process = new Process();

            process.StartInfo.FileName =
                Process.GetCurrentProcess().MainModule.FileName;

            process.StartInfo.Arguments =
                $"child \"{filePath}\" {word}";

            process.StartInfo.UseShellExecute = false;

            process.Start();
            process.WaitForExit();

            Console.ReadLine();
        }
    }
}
