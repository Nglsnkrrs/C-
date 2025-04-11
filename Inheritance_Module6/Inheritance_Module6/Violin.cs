using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Violin : MusicalInstrument
    {
        public Violin(string name, string description) : base(name, description)
        {}

        public override void Sound()
        {
            Console.WriteLine("Sound: melodiousness");
        }

        public override void History() 
        {
            Console.WriteLine("History: It is believed that the violin \n" +
                "as a musical instrument was invented in Italy\n" +
                " in the first half of the 16th century1.\n " +
                "The first mentions of it date back to 1523-1524");
        }
    }
}
