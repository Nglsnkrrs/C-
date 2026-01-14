using System;
using System.Threading;

namespace Task_2
{
    class Child
    {
        public static int Run()
        {
            Console.WriteLine("Дочерний процесс запущен.");
            Console.WriteLine("Работаю 10 секунд...");

            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(10000);
                Console.WriteLine($"Секунда {i}");
            }

            Console.WriteLine("Дочерний процесс завершён нормально.");
            return 5;
        }
    }
}
