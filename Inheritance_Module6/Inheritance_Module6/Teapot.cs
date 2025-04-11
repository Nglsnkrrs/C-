using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Teapot : Device
    {
        public Teapot(string name, string characteristic) : base(name, characteristic)
        {}

        public override void Sound()
        {
            Console.WriteLine("Sound: Whistling");
        }
    }
}
