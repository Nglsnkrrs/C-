using System;

namespace Module_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1 task1 = new Task1();
            Task2 task2 = new Task2();

            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1) Task #1");
                Console.WriteLine("2) Task #2");
                Console.Write("Your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Please enter a length: ");
                        int length = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter a symbol: ");
                        char symbol = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine("Result");
                        task1.Square(length, symbol);
                        break;
                    case 2:
                        Console.Write("Please enter a number: ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(task2.Palindrome(number));
                        break;
                }
            }
        }
    }
}
