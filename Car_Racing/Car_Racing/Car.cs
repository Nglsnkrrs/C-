using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Racing
{
    public abstract class Car
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public double Position { get; protected set; }
        public Car(string name)
        {
            Name = name;
            Speed = 0;
            Position = 0;
        }
        public abstract void Move();

        public event Action<Car> Finished;

        protected static Random random = new Random();

        protected void OnFinish()
        {
            Finished?.Invoke(this);
        }
    }
}
