using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Module_2
{
    internal class Program
    {
        static void Task1()
        {
            int[] A = new int[5];
            int row = 3, cols = 4;
            double[,] B = new double[row, cols];

            Console.WriteLine("Please enter 5 elements of a one-dimensional array: ");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"Please enter {i} element: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }

            Random random = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    B[i, j] = Math.Round(random.NextDouble() * 100, 2);
                }
            }
            Console.WriteLine("Array A");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Array B");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int minA = A[0];
            int maxA = A[0];

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < minA) { minA = A[i]; };
                if (A[i] > maxA) { maxA = A[i]; };
            }
            Console.WriteLine($"Min element in A: {minA}, Max element in A: {maxA}");

            double minB = B[0, 0];
            double maxB = B[0, 0];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (B[i, j] < minB) { minB = B[i, j]; };
                    if (B[i, j] > maxB) { maxB = B[i, j]; };
                }
            }
            Console.WriteLine($"Min element in B: {minB}, Max element in B: {maxB}");

            int sumA = 0;
            int productA = 1;
            int sumEvenA = 0;
            foreach (int item in A)
            {
                sumA += item;
                productA *= item;

                if (item % 2 == 0)
                {
                    sumEvenA += item;
                }
            }
            Console.WriteLine($"Sum array A: {sumA}, product element: {productA}, " +
                $"the sum of even elements {sumEvenA}");


            double sumB = 0;
            double productB = 1;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sumB += B[i, j];
                    productB *= B[i, j];
                }
            }
            Console.WriteLine($"Sum array B: {sumB}, product element: {productB}");
            Console.WriteLine($"Total amount A+B: {sumA + sumB}, the product of A*B: {productA * productB}");

            double sumCols = 0;
            for (int i = 0; i < cols; i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = 0; j < row; j++)
                    {
                        sumCols += B[j, i];
                    }
                }
            }
            Console.WriteLine("The sum of the odd columns of the array В: " + sumCols);
        }

        static void Task2()
        {
            int rows = 5, cols = 5;
            int[,] array = new int[rows, cols];

            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = random.Next(-100, 101);
                }
            }

            Console.WriteLine("Array");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int minElem = array[0, 0];
            int maxElem = array[0, 0];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] < minElem) { minElem = array[i, j]; };
                    if (array[i, j] > maxElem) { maxElem = array[i, j]; };
                }
            }
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] > minElem && array[i, j] < maxElem)
                    {
                        sum += array[i, j];
                    }
                }
            }
            Console.WriteLine($"the sum of the elements between " +
                $"the maximum and minimum elements: {sum}");
        }
        static string Encrypt(string text, int shift)
        {
            char[] chars = text.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsUpper(chars[i]))
                {
                    chars[i] = (char)(((chars[i] - 'A' + shift) % 26) + 'A');
                }
                else if (char.IsLower(chars[i]))
                {
                    chars[i] = (char)(((chars[i] - 'a' + shift) % 26) + 'a');
                }
            }

            return new string(chars);
        }

        static string Decrypt(string text, int shift)
        {
            return Encrypt(text, 26 - (shift % 26));
        }

        static void Task3()
        {
            Console.WriteLine("1. Encrypt it");
            Console.WriteLine("2. Decrypt");
            Console.Write("Your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the text: ");
            string text = Console.ReadLine();

            Console.Write("Enter the shift: ");
            int shift = Convert.ToInt32((Console.ReadLine()));

            string result;
            switch (choice)
            {
                case 1:
                    result = Encrypt(text, shift); 
                    Console.WriteLine("Encrypted text: " + result);
                    break;
                case 2:
                    result = Decrypt(text, shift);
                    Console.WriteLine("The decrypted text: " + result); 
                    break;
            }

        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Task №1");
                Console.WriteLine("2. Task №2");
                Console.WriteLine("3. Task №3");
                Console.Write("Your choice: ");
                int Choice = Convert.ToInt32(Console.ReadLine());

                switch (Choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3(); 
                        break;
                }
            }
        }




        
    }
}




