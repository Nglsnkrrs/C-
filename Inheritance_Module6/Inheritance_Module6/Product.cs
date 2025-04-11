using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Product : Money
    {
        public string Name { get; set; }
        public double Reduce { get; set; }

        public double resultCost;
        public double NewCost;
        public double Convert()
        {
            resultCost = Whole_part + (Kopecks /
                Math.Pow(10, Kopecks.ToString().Length));
            return resultCost;
        }

        public void ProductName()
        {
            Console.Write("Please enter a name of product: ");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter a cost of product");
            WholePart();
            Pennies();
        }

        public double ReduceThePrice()
        {
            Console.Write("Please enter a number to reduce the price: ");
            Reduce = double.Parse(Console.ReadLine());

            if (Whole_part < Reduce)
            {
                Console.WriteLine("Eror! The cost is less than the specified number");
            }
            else 
            {
                NewCost = resultCost - Reduce;
                Console.WriteLine("New cost: "+ NewCost);
            }
            return NewCost;
        }

        public void PrintProductInfo()
        {
            Console.WriteLine("Name: " + Name);
            Print();
        }

        public void PrintProductNewInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Cost: " + NewCost);
        }
    }
}
