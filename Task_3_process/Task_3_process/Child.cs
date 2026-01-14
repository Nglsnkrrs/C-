using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_process
{
    class Child
    {
        public static int Run(string[] args)
        {
            int x = int.Parse(args[1]);
            int y = int.Parse(args[2]);
            string op = args[3];

            Console.WriteLine($"Получены аргументы:");
            Console.WriteLine($"Число 1: {x}");
            Console.WriteLine($"Число 2: {y}");
            Console.WriteLine($"Операция: {op}");

            int result = 0;

            switch (op)
            {
                case "+":
                    result = x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case "*":
                    result = x * y;
                    break;
                case "/":
                    result = x / y;
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    return -1;
            }

            Console.WriteLine($"Результат: {result}");
            return 0;
        }
    }
}
