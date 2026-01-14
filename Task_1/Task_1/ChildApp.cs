using System;

namespace Task_1
{
    class Child
    {
        public static int Run()
        {
            Console.WriteLine("Дочерний процесс работает");
            Console.ReadLine();
            return 3; 
        }
    }
}
