using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Violoncello : MusicalInstrument
    {
        public Violoncello(string name, string description) : base(name, description)
        {}

        public override void Sound()
        {
            Console.WriteLine("Sound: ");
        }

        public override void History()
        {
            Console.WriteLine("History: The history of the cello dates\n" +
                " back to the beginning of the 16th century. \n" +
                "Initially, it was used as a bass instrument to\n " +
                "accompany singing or playing on an instrument of a higher register.\n");
        }
    }
}
