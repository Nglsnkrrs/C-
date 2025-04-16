using System.ComponentModel.Design;

namespace Operator_overload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1) Task 1");
                Console.WriteLine("2) Task 2");
                Console.WriteLine("3) Task 3");
                Console.Write("Your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Magazine mag1 = new Magazine("Komsomolskaya Pravda", 1925, 
                            "daily socio-political newspaper", "+7 (495) 777-02-82", "https://www.kp.ru/", 60);
                        Magazine mag2 = new Magazine("National Geographic", 1888,
                            "National Geographic has been at the forefront of science, technology, and environmental news",
                            "02 714 31 66", "ngmintl@subscription.co.uk", 84);
                        Magazine mag3 = new Magazine ("Time", 1923, "News magazine", 
                            "+1-212-522-1212", "letters@time.com", 83);
                        
                        mag1.Print();
                        mag2.Print();
                        mag3.Print();
                        Console.WriteLine();

                        mag1 += 3;
                        mag2 -= 2;

                        Console.WriteLine("After overloading is performed");
                        Console.WriteLine($"Number of employees {mag1.Name}: {mag1.EmployeeCount}");
                        Console.WriteLine($"Number of employees {mag2.Name}: {mag2.EmployeeCount}");

                        Console.WriteLine($"\nEmployee Comparison:");
                        Console.WriteLine($"{mag1.Name} == {mag2.Name}: {mag1 == mag2}");
                        Console.WriteLine($"{mag1.Name} != {mag2.Name}: {mag1 != mag2}");
                        Console.WriteLine($"{mag1.Name} > {mag2.Name}: {mag1 > mag2}");
                        Console.WriteLine($"{mag1.Name} < {mag2.Name}: {mag1 < mag2}");

                        Console.WriteLine($"\n{mag1.Name}.Equals({mag3.Name}): {mag1.Equals(mag3)}");
                        break;
                    case 2:
                        Shop shop1 = new Shop("Letual", "Meganom Yevpatoriyskoe shosse, 8",
                            "cosmetics store", "8-800-200-23-45", "Letual@gmail.com", 64.5);
                        Shop shop2 = new Shop("Sunlight", "Meganom Yevpatoriyskoe shosse, 8", 
                            "Jewelry Store", "+7 (495) 668-658-0", "Sunlight@gmail.com", 11.6);
                        Shop shop3 = new Shop("Ostin", "Meganom Yevpatoriyskoe shosse, 8",
                            "clothing store", "8 800 777-4-999", "support@ostin.com", 64.5);
                        
                        shop1.Print();
                        shop2.Print();
                        shop3.Print();
                        Console.WriteLine();

                        shop1 += 10.6;
                        shop2 -= 3.6;

                        Console.WriteLine("After overloading is performed");
                        Console.WriteLine($"Store area {shop1.Name}: {shop1.Square}");
                        Console.WriteLine($"Store area {shop2.Name}: {shop2.Square}");

                        Console.WriteLine("Area comparison");
                        Console.WriteLine($"{shop1.Name} == {shop2.Name}: {shop1 == shop2}");
                        Console.WriteLine($"{shop1.Name} != {shop2.Name}: {shop1 != shop2}");
                        Console.WriteLine($"{shop1.Name} > {shop2.Name}: {shop1 > shop2}");
                        Console.WriteLine($"{shop1.Name} < {shop2.Name}: {shop1 < shop2}");

                        Console.WriteLine($"\n{shop1.Name}.Equals({shop1.Name}): {shop1.Equals(shop3)}");
                        break;
                
                }
            }
        }
    }
}
