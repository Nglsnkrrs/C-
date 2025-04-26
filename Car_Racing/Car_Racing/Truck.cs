using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Racing
{
    public class Truck : Car
    {
        public Truck(string name) : base(name)
        { }

        public override void Move()
        {
            Speed = Math.Round(random.NextDouble() * (15 - 7) + 7, 1);
            Position += Speed;

            if (Position >= 100)
                OnFinish();
        }
    }
}
