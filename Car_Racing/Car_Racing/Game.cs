using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Racing
{
    public class Game
    {
        private List<Car> cars = new List<Car>();
        private bool raceFinished = false;

        public delegate void RaceAction();
        public event RaceAction OnStartRace;
        public event RaceAction OnUpdateRace;

        public void AddCar(Car car)
        {
            car.Finished += CarFinished;
            cars.Add(car);
        }

        private void CarFinished(Car car)
        {
            if (!raceFinished)
            {
                raceFinished = true;
                Console.WriteLine($"\n🚗 Winner: {car.Name}!");
            }
        }

        public void Start()
        {
            Console.WriteLine("The race has begun!\n");
            OnStartRace?.Invoke();

            while (!raceFinished)
            {
                OnUpdateRace?.Invoke();
                Thread.Sleep(500);
            }
        }

    }
}
