using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Team
    {
        private List<IWorker> workers;

        public Team(List<IWorker> workersList)
        {
            workers = workersList;
        }

        public void BuildHouse(House house)
        {
            while (!house.IsFinished())
            {
                foreach (var worker in workers)
                {
                    if (house.IsFinished()) break;
                    worker.Work(house);
                }
            }

            house.ShowHouse();
        }
    }
}
