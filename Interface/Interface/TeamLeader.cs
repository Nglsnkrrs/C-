using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class TeamLeader : IWorker
    {
        public string Name;
        public TeamLeader(string name) { Name = name; }
        public void Work(House house)
        {
            Console.WriteLine($"\n{this.Name} makes a check:");
            house.ShowProgress();
        }
    }
}
