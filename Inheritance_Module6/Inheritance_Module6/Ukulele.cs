using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Ukulele : MusicalInstrument
    {
        public Ukulele(string name, string description) : base(name, description)
        {}

        public override void Sound()
        {
            Console.WriteLine("Sound: strumming");
        }

        public override void History()
        {
            Console.WriteLine("History: The history of the ukulele begins at the end of the 19th century,\n " +
                "when Portuguese immigrants from Madeira and the Azores arrived in Hawaii to work on sugar plantations.\n " +
                "Among their luggage were small guitar—like instruments - \n" +
                "bragigna and cavaquinho, which became the prototypes of the ukulele.");
        }
    }
}
