using System;

namespace Module_3
{
    public class Task1
    {
        public Task1() { }
        public void Square(int length, char symbol)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(symbol + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
