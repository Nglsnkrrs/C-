using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_in_Stock
{
    public class Stock
    {
        private static Random random = new Random();

        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public List<Car> carList { get; set; }
        public Stock(int id, string city)
        {
            Id = id;
            City = city;
            Description = $"Stock in {city}";
            carList = new List<Car>();
        }

        private static List<string> warehouseCity = new List<string>
        {
            "Rome", "Berlin", "Milan", "Moscow"
        };

        public static List<Stock> AddCars()
        {
            var stocks = new List<Stock>();

            int stockIdCounter = 1;

            foreach (string city in warehouseCity)
            {
                var stock = new Stock(stockIdCounter++, city);
                int carCount = random.Next(10, 51);
                for (int i = 0; i < carCount; i++)
                {
                    stock.carList.Add(Car.Generator());
                }
                stocks.Add(stock);

            }

            return stocks;
        }

        public void PrintAllCars()
        {
            Console.WriteLine($"Warehouse {Id} in the city {City}: {carList.Count} cars");
            foreach (var car in carList)
            {
                Console.WriteLine($"  ID: {car.Id}, Name: {car.Name}, Year of release: {car.DateRelease}, Cost: {car.Cost}, Note: {car.Remark}");
            }
            Console.WriteLine();
        }

    }

}
