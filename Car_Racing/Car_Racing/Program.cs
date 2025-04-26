using System.Diagnostics;

namespace Car_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game race = new Game();

            var car1 = new SportCar("Спорткар #1");
            var car2 = new Truck("Грузовик #1");
            var car3 = new Bus("Автобус #1");

            race.AddCar(car1);
            race.AddCar(car2);
            race.AddCar(car3);

            race.OnStartRace += () =>
            {
                Console.WriteLine("All cars at the start!");
            };

            race.OnUpdateRace += () =>
            {
                foreach (var car in new Car[] { car1, car2, car3 })
                {
                    car.Move();
                    Console.WriteLine($"{car.Name} on the position {car.Position:F1} km (speed {car.Speed} km/h)");
                }
                Console.WriteLine();
            };
            race.Start();

            Console.WriteLine("\nThe race is over!");
        }
    }
}
