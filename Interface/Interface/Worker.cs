using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Worker : IWorker
    {
        public string Name;
        public Worker(string name) { Name = name; }

        public void Work(House house)
        {
            if (house.Parts.Count(p => p is Basement) < 1)
                house.Parts.Add(new Basement());
            else if (house.Parts.Count(p => p is Walls) < 4)
                house.Parts.Add(new Walls());
            else if (house.Parts.Count(p => p is Window) < 4)
                house.Parts.Add(new Window());
            else if (house.Parts.Count(p => p is Door) < 1)
                house.Parts.Add(new Door());
            else if (house.Parts.Count(p => p is Roof) < 1)
                house.Parts.Add(new Roof());
            else
                return;

            Console.WriteLine($"{Name} built: {house.Parts.Last().Name}");
        }
    }
}
