using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_in_Stock
{
    public class LinqExtensionMethods
    {
        public void CarAlfa_RomeoLinq(List<Stock> stockList)
        {
            var result = new List<Report>();

            foreach (var stock in stockList)
            {
                var cars = stock.carList
                    .Where(car => car.Name == "Alfa_Romeo")
                    .Select(car => new Report
                    {
                        CarId = car.Id,
                        CarName = car.Name,
                        DateRelease = car.DateRelease,
                        Cost = car.Cost,
                        Remark = car.Remark,
                        City = stock.City,
                        StockId = stock.Id,
                        StockDescription = stock.Description
                    });

                result.AddRange(cars);
            }

            foreach (var car in result)
            {
                Console.WriteLine($"ID: {car.CarId}, Name: {car.CarName}, " +
                    $"Year of release: {car.DateRelease}, Cost: {car.Cost}");
            }

            ReportManager.SaveReportToFile(result, "Cars_Alfa_Romeo");
            Console.WriteLine();
        }
        public void StockBMWLinq(List<Stock> stockList)
        {
            var result = new List<Report>();

            foreach (var stock in stockList)
            {
                var cars = stock.carList
                    .Where(car => car.Name.Contains("BMW"))
                    .Select(car => new Report
                    {
                        CarId = car.Id,
                        CarName = car.Name,
                        DateRelease = car.DateRelease,
                        Cost = car.Cost,
                        Remark = car.Remark,
                        City = stock.City,
                        StockId = stock.Id,
                        StockDescription = stock.Description
                    });

                result.AddRange(cars);
            }
               
            Console.WriteLine("\n:Warehouses containing BMW cars");
            foreach (var stock in result)
            {
                Console.WriteLine($"Склад {stock.StockId} in the City {stock.City} contains BMW");
            }

            ReportManager.SaveReportToFile(result, "Stocks_BMW");
            Console.WriteLine();
        }
        public void Car10000Linq(List<Stock> stockList)
        {
            var result = new List<Report>();

            foreach (var stock in stockList)
            {
                var cars = stock.carList
                    .Where(car => car.Cost <= 1000)
                    .Select(car => new Report
                    {
                        CarId = car.Id,
                        CarName = car.Name,
                        DateRelease = car.DateRelease,
                        Cost = car.Cost,
                        Remark = car.Remark,
                        City = stock.City,
                        StockId = stock.Id,
                        StockDescription = stock.Description
                    });

                result.AddRange(cars);
            }
            foreach (var car in result)
            {
                Console.WriteLine($"ID: {car.CarId}, Name: {car.CarName}, " +
                    $"Year of release: {car.DateRelease}, Cost: {car.Cost}");
            }
            ReportManager.SaveReportToFile(result, "Car_less_than_10000");
            Console.WriteLine();
        }
        public void CarRemarkLinq(List<Stock> stockList)
        {
            var result = new List<Report>();

            foreach (var stock in stockList)
            {
                var cars = stock.carList
                    .Where(car => !string.IsNullOrEmpty(car.Remark))
                    .OrderBy(car => car.Name)
                    .Select(car => new Report
                    {
                        CarId = car.Id,
                        CarName = car.Name,
                        DateRelease = car.DateRelease,
                        Cost = car.Cost,
                        Remark = car.Remark,
                        City = stock.City,
                        StockId = stock.Id,
                        StockDescription = stock.Description
                    });

                result.AddRange(cars);
            }
            foreach (var car in result)
            {
                Console.WriteLine($"ID: {car.CarId}, Name: {car.CarName}, " +
                    $"Year of release: {car.DateRelease}, Cost: {car.Cost}");
            }
            ReportManager.SaveReportToFile(result, "Car_Remark");
            Console.WriteLine();
        }
        public void StocksWithCarsFrom2000to2005(List<Stock> stockList)
        {
            var result = new List<Report>();

            foreach (var stock in stockList)
            {
                var cars = stock.carList
                    .Where(car => car.DateRelease >= 2000 && car.DateRelease <= 2005)
                    .Select(car => new Report
                    {
                        CarId = car.Id,
                        CarName = car.Name,
                        DateRelease = car.DateRelease,
                        Cost = car.Cost,
                        Remark = car.Remark,
                        City = stock.City,
                        StockId = stock.Id,
                        StockDescription = stock.Description
                    })
                    .ToList();

                if (cars.Any())
                {
                    result.AddRange(cars);
                }
            }

            var stocksWithCarCount = stockList
                .Where(stock => stock.carList.Any(car => car.DateRelease >= 2000 && car.DateRelease <= 2005))
                .OrderByDescending(stock => stock.carList.Count(car => car.DateRelease >= 2000 && car.DateRelease <= 2005))
                .ToList();

            Console.WriteLine("\nWarehouses with machines from 2000-2005, sorted by number of machines:");

            foreach (var stock in stocksWithCarCount)
            {
                var carCount = stock.carList.Count(car => car.DateRelease >= 2000 && car.DateRelease <= 2005);
                Console.WriteLine($"Warehouses {stock.Id} in the City {stock.City} — total cars: {carCount}");
            }

            ReportManager.SaveReportToFile(result, "Stocks_2000_2005");
            Console.WriteLine();
        }
        public void CarDateReleaseLinq(List<Stock> stockList)
        {
            var result = new List<Report>();

            foreach (var stock in stockList)
            {
                var cars = stock.carList
                    .Where(car => car.DateRelease <= 2000)
                    .OrderBy(car => car.DateRelease)
                    .Select(car => new Report
                    {
                        CarId = car.Id,
                        CarName = car.Name,
                        DateRelease = car.DateRelease,
                        Cost = car.Cost,
                        Remark = car.Remark,
                        City = stock.City,
                        StockId = stock.Id,
                        StockDescription = stock.Description
                    });

                result.AddRange(cars);
            }
   
            foreach (var car in result)
            {
                Console.WriteLine($"ID: {car.CarId}, Name: {car.CarName}, " +
                    $"Year of release: {car.DateRelease}, Cost: {car.Cost}");
            }
            ReportManager.SaveReportToFile(result, "Car_Date_Release");
            Console.WriteLine();
        }
    }
}
