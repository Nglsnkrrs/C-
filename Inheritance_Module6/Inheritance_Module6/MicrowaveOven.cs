using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class MicrowaveOven : Device
    {
        public MicrowaveOven(string name, string description) : base(name, description)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Sound: Pip-Pip");
        }
    }
}
