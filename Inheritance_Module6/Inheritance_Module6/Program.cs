namespace Inheritance_Module6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {

                Console.WriteLine("Menu");
                Console.WriteLine("1. Task №1");
                Console.WriteLine("2. Task №2");
                Console.WriteLine("3. Task №3");
                Console.WriteLine("4. Task №4");
                Console.Write("Your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Money money = new Money();
                        Product product = new Product();

                        money.WholePart();
                        money.Pennies();
                        money.Print();

                        Console.WriteLine();

                        product.ProductName();
                        product.PrintProductInfo();
                        product.Convert();
                        product.ReduceThePrice();
                        product.PrintProductNewInfo();
                        break;
                    case 2:

                        Device Teapot = new Teapot("Vitek", "Electric kettle");
                        Device MicrowaveOven = new MicrowaveOven("LG", "The dimensions of the " +
                            "device are 45.5× 26×33 centimeters.");
                        Device Car = new Car("BMW M5", "Drive full acceleration" +
                            " to 100 km/h in 3 seconds");
                        Device Steamboat = new Steamboat("The Englishman", "It was built in 1860 " +
                            "in England, in Newcastle.");

                        Teapot.Show();
                        Teapot.Sound();
                        Teapot.Desc();

                        Console.WriteLine();
                        MicrowaveOven.Show();
                        MicrowaveOven.Sound();
                        MicrowaveOven.Desc();

                        Console.WriteLine();
                        Car.Show();
                        Car.Sound();
                        Car.Desc();

                        Console.WriteLine();
                        Steamboat.Show();
                        Steamboat.Sound(); 
                        Steamboat.Desc();
                        break;
                    case 3:

                        MusicalInstrument Violin = new Violin("Violin", "4 strings");
                        MusicalInstrument Trombone = new Trombone("Trombone", "wind instrument");
                        MusicalInstrument Ukulele = new Ukulele("Ukulele", "4 strings");
                        MusicalInstrument Violoncello = new Violoncello("Violoncello", "4 strings");

                        Violin.Show();
                        Violin.History();
                        Violin.Sound();
                        Violin.Desc();

                        Console.WriteLine();
                        Trombone.Show();
                        Trombone.History();
                        Trombone.Sound();
                        Trombone.Desc();

                        Console.WriteLine();
                        Ukulele.Show();
                        Ukulele.History();
                        Ukulele.Sound();
                        Ukulele.Desc();

                        Console.WriteLine();
                        Violoncello.Show();
                        Violoncello.History();
                        Violoncello.Sound();
                        Violoncello.Desc();
                        break;
                    case 4:

                        Worker[] workers = new Worker[]
                        {
                            new President(30, "Frances","Baker", 200000, "President"),
                            new Security(25, "Ronald","Johnson", 40000, "Security"),
                            new Manager(45,"John","Bailey", 85000, "Manager"),
                            new Engineer(60, "Martin","Higgins", 90000, "Engineer"),
                        };

                        foreach (Worker worker in workers)
                        {
                            worker.Print();
                            Console.WriteLine();
                        }
                        break;
                }
            
            }



            

            


            //

            


        }
    }
}
