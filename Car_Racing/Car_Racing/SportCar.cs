using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Racing
{
    public class SportCar : Car
    {
        public SportCar(string name) : base(name) { }
        public override void Move()
        {
            Speed = Math.Round(random.NextDouble() * (36 - 12) + 12, 1);
            Position += Speed;

            if (Position >= 100)
                OnFinish();
        }
    }
}
