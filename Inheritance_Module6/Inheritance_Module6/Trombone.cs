using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Trombone : MusicalInstrument
    {
        public Trombone(string name, string description) : base(name, description)
        {}

        public override void Sound()
        {
            Console.WriteLine("Sound: loud sound");
        }

        public override void History()
        {
            Console.WriteLine("History: the history of the creation of the trombone begins in the XV century.\n " +
                "It is generally believed that the immediate predecessors of this instrument were backstage pipes, \n" +
                "when playing on which the musician had the opportunity to move \n" +
                "the instrument's tube, thus obtaining a chromatic scale.\n " +
                "Such pipes were used to double the voices of the church choir, given the similarity \n" +
                "of the timbre of the pipe to the human voice.");
        }

    }
}
