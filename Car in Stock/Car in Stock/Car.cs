using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_in_Stock
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DateRelease { get; set; }
        public int Cost { get; set; }
        public string Remark { get; set; }
        public bool IsStock { get; set; } = false;

        private static Random random = new Random();
        private static int carIdCounter = 1;

        private const int minCost = 1000;
        private const int maxCost = 500000;

        private static List<string> carBrands = new List<string>
        {
            "Cadillac", "Cadillac CT4","Cadillac CT5",
            "BMW M5", "BMW X6","BMW F10",
            "Hyundai Solaris", "Hyundai Sonata","Hyundai Creta",
            "Reno Logan", "Reno Duster", "Reno Megane",
            "Volvo S60","Volvo 240","Volvo 940",
            "Lada Priora", "Lada Granta","Lada 2107",
            "Porsche Panamera", "Porsche Cayenne","Porsche Macan",
            "Infinity FX","Infinity QX70","Infinity EX",
            "Suzuki Swift","Suzuki SX4","Suzuki Vitara",
            "Toyota Camry","Toyota Corolla","Toyota Prius",
            "Mercedes Benz E-Class", "Mercedes Benz S-Class","Mercedes Benz AMG GT",
            "Ford Focus", "Ford Kuga","Ford Mondeo",
            "Alfa_Romeo", "Alfa_Romeo 166", "Alfa_Romeo GTV",
            "Nissan Juke","Nissan Almera","Nissan X-Trail",
        };

        public static Car Generator()
        {
            string name = carBrands[random.Next(carBrands.Count)];
            int dateRelease = random.Next(1998, 2018);
            int age = DateTime.Now.Year - dateRelease;
            int depreciation = age * random.Next(5000, 200000);
            int cost = Math.Max(minCost, maxCost - depreciation);

            return new Car
            {
                Id = carIdCounter++,
                Name = name,
                DateRelease = dateRelease,
                Cost = cost,
                Remark = dateRelease >= 2016 ? "Inspection completed" : "",
                IsStock = true
            };
        }

    }



}
