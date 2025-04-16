using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class House
    {
        public List<IPart> Parts = new List<IPart>();

        public bool IsFinished()
        {
            return Parts.Count(p => p is Basement) == 1 &&
                   Parts.Count(p => p is Walls) == 4 &&
                   Parts.Count(p => p is Window) == 4 &&
                   Parts.Count(p => p is Door) == 1 &&
                   Parts.Count(p => p is Roof) == 1;
        }

        public void ShowProgress()
        {
            Console.WriteLine("\nCurrent construction progress:");
            foreach (var part in Parts.GroupBy(p => p.Name))
            {
                Console.WriteLine($"{part.Key}: {part.Count()}");
            }
            Console.WriteLine();
        }
        public void ShowHouse()
        {
            Console.WriteLine(@"
                   _______
                  /      /\
                 /      /  \
                /______/___/|
                |      |   ||
                |  []  |   ||
                |______|___|/
            ");
        }

    }
}
