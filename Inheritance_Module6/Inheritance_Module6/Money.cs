using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Money
    {
        public int Whole_part { get; set; }
        public int Kopecks { get; set; }

        public void WholePart()
        {
            Console.Write("Please enter a whole part of money: ");
            Whole_part = Convert.ToInt32(Console.ReadLine());
        }
        public void Pennies()
        {
            Console.Write("Please enter a pennies of money: ");
            Kopecks = Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine($"The amount {Whole_part} and {Kopecks} kopecks");
        }
    }
}
