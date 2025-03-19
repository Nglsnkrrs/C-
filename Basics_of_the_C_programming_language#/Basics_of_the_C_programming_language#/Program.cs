using System;
internal class Program
{
    static void Task1(int UserNumber)
    {

        if (UserNumber < 1 || UserNumber > 100)
        {
            Console.WriteLine("Error! The number is not in the range from 1 to 100");
            return;
        }

        if (UserNumber % 3 == 0 && UserNumber % 5 == 0)
        {
            Console.WriteLine("Fizz Buzz");
        }
        else if (UserNumber % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (UserNumber % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine("User number: " + UserNumber);
        }

    }

    static double Task2(int Number, int Percent)
    {
        double Result = (Percent * Number) / 100.0;

        return Result;
    }

    static string Task3(int Num1, int Num2, int Num3, int Num4)
    {
        string Result = Convert.ToString(Num1) + Convert.ToString(Num2) + Convert.ToString(Num3) + Convert.ToString(Num4);
        return Result;
    }

    static string Task4(string Num)
    {
        string result = "";
        if (Num.Length == 6)
        {
            Console.Write("Введите первый разряд для обмена (1-6): ");
            int pos1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите второй разряд для обмена (1-6): ");
            int pos2 = Convert.ToInt32(Console.ReadLine());
            char[] digits = Num.ToCharArray();

            char temp = digits[pos1 - 1];
            digits[pos1 - 1] = digits[pos2 - 1];
            digits[pos2 - 1] = temp;

            result = new string(digits);

        }
        else
        {
            Console.WriteLine("The number is not a 6 digit number");
        }
        return result;
    }

    static void Task6(int choice)
    {
        double degreesResultInFahrenheit = 0;
        double degreesResultInCelsius = 0;
        if (choice == 1)
        {
            Console.Write("Enter the temperature in Celsius: ");
            double degreesCelsius = Convert.ToDouble(Console.ReadLine());
            degreesResultInFahrenheit = ((degreesCelsius * 9) / 5) + 32;
            Console.WriteLine("The degrees obtained after converting Celsius to Fahrenheit: " + degreesResultInFahrenheit);

        }
        else if (choice == 2)
        {
            Console.Write("Enter the temperature in Fahrenheit: ");
            double degreesFahrenheit = Convert.ToDouble(Console.ReadLine());
            degreesResultInCelsius = ((degreesFahrenheit - 32) * 5) / 9;
            Console.WriteLine("The degrees obtained after converting Fahrenheit to Celsius: " + degreesResultInCelsius);
        }
        else
        {
            Console.WriteLine("You entered the wrong number.");
        }
    }
    static void Task7(int num1, int num2)
    {
        if (num1 > num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }

        Console.WriteLine($"Четные числа в диапазоне от {num1} до {num2}:");

        for (int i = num1; i <= num2; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 3");
            Console.WriteLine("4. Task 4");
            Console.WriteLine("5. Task 6");
            Console.WriteLine("6. Task 7");
            Console.Write("Your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Please enter a number: ");
                        int UsNum = Convert.ToInt32(Console.ReadLine());
                        Task1(UsNum);
                        break;
                    }
                case 2:
                    {
                        Console.Write("Please enter a number: ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter a percent: ");
                        int percent = Convert.ToInt32(Console.ReadLine());
                        double res = Task2(number, percent);
                        Console.WriteLine("Percent: " + res);
                        break;
                    }
                case 3:
                    {
                        Console.Write("Please enter a number 1: ");
                        int Number1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter a number 2: ");
                        int Number2 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter a number 3: ");
                        int Number3 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter a number 4: ");
                        int Number4 = Convert.ToInt32(Console.ReadLine());
                        string Result = Task3(Number1, Number2, Number3, Number4);
                        Console.WriteLine("Result number: " + Result);
                        break;
                    }
                case 4:
                    {
                        Console.Write("Please enter a six-digit number: ");
                        string Num = Console.ReadLine();
                        string Result1 = Task4(Num);
                        Console.WriteLine("Result number: " + Result1);
                        break;

                    }
                case 5:
                    {
                        Console.Write("If you enter the temperature in Celsius, press 1, if in Fahrenheit, press 2: ");
                        int UserChoice = Convert.ToInt32(Console.ReadLine());
                        Task6(UserChoice);
                        break;
                    }
                case 6:
                    {
                        Console.Write("Please enter first number: ");
                        int First = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter second number: ");
                        int Second = Convert.ToInt32(Console.ReadLine());
                        Task7(First, Second);
                        break;
                    }
            }
        }


    }
}
