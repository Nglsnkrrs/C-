using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_in_Stock
{
    public class Program
    {
        static void Main(string[] args )
        {
            var stockList = Stock.AddCars();

            var extensionMethods = new LinqExtensionMethods();

            extensionMethods.CarAlfa_RomeoLinq(stockList);

            Console.WriteLine("=========================================");
            extensionMethods.StockBMWLinq(stockList);
            Console.WriteLine("=========================================");

            extensionMethods.Car10000Linq(stockList);
            Console.WriteLine("=========================================");

            extensionMethods.CarRemarkLinq(stockList);
            Console.WriteLine("=========================================");

            extensionMethods.StocksWithCarsFrom2000to2005(stockList);
            Console.WriteLine("=========================================");

            extensionMethods.CarDateReleaseLinq(stockList);
        }
    }
}
