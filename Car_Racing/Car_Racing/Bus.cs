using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Racing
{
    public class Bus : Car
    {
        public Bus(string name) : base(name)
        { }

        public override void Move()
        {
            Speed = Math.Round(random.NextDouble() * (25 - 10) + 10, 1);
            Position += Speed;

            if (Position >= 100)
                OnFinish();
        }
    }
}
