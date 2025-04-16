using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Introduction_to_classes
{
    internal class Program
    {
        public static T[] FilterArray<T>(T[] originalArray, T[] filterArray)
        {
            return originalArray.Where(item => !filterArray.Contains(item)).ToArray();
        }
        static void Main(string[] args)
        {
            int ch;
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1) Task 3");
                Console.WriteLine("2) Task 4");
                Console.WriteLine("3) Task 5");
                Console.WriteLine("4) Task 6");
                Console.Write("Your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());  

                switch (choice) { 
                    case 1:
                        int[] originalArray = { 1, 2, 6, -1, 88, 7, 6 };
                        int[] filterArray = { 6, 88, 7 };

                        int[] result = FilterArray(originalArray, filterArray);

                        Console.WriteLine(string.Join(" ", result));
                        break;
                    case 2:
                        Console.WriteLine("1 - fill in the data manually 2 - Filling in via the constructor");
                        ch = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Choice: ");
                        if (ch == 1)
                        {
                            Website site1 = new Website();
                            site1.InputInfo();
                            site1.PrintInfo();
                        }
                        else if (ch == 2)
                        {
                            Website site2 = new Website(
                            "Journal",
                            "https://journal.top-academy.ru",
                            "Study diary",
                            "142.250.185.206");
                            site2.PrintInfo();

                            site2.SetName("Journal Top");
                            Console.WriteLine($"\nUpdated name: {site2.GetName()}");
                        } else
                            Console.WriteLine("You entered an incorrect number.");
                        break;
                    case 3:
                        Console.WriteLine("1 - fill in the data manually 2 - Filling in via the constructor");
                        Console.Write("Choice: ");
                        ch = Convert.ToInt32(Console.ReadLine());
                        if (ch == 1)
                        {
                            Magazine mag1 = new Magazine();
                            mag1.Info();
                            mag1.Print();
                        }
                        else if (ch == 2)
                        {
                            Magazine mag2 = new Magazine(
                            "The C Guide#",
                            2020,
                            "Educational Programming Tutorial",
                            "+79785451232",
                            "microsoft@mic.com");
                            mag2.Print();
                            mag2.SetContactEmail("Magazine@gmail.com");
                            Console.WriteLine($"\nUpdated contact email: {mag2.GetContactEmail()}");
                        }
                        else
                            Console.WriteLine("You entered an incorrect number.");
                        break;
                    case 4:
                        Console.WriteLine("1 - fill in the data manually 2 - Filling in via the constructor");
                        Console.Write("Choice: ");
                        ch = Convert.ToInt32(Console.ReadLine());
                        if (ch == 1)
                        {
                            Shop shop1 = new Shop();
                            shop1.Input();
                            shop1.Print();
                        }
                        else if (ch == 2)
                        {
                            Shop shop2 = new Shop(
                                "Wildberries",
                                "Online shop",
                                "Marketplace",
                                "+8 644 45 65 55",
                                "wb@mail.ru");
                            shop2.Print();

                            shop2.SetName("Ozon");
                            Console.WriteLine($"\nNew name {shop2.GetName()}");
                        }
                        else
                            Console.WriteLine("You entered an incorrect number.");
                        break;

                }
            }
        }
    }
}
