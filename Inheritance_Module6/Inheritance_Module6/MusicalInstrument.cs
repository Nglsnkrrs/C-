using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class MusicalInstrument
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public MusicalInstrument(string name, string description) {

            Name = name;
            Description = description;
        }

        public virtual void Sound()
        {
            Console.WriteLine("Sound: ");
        }

        public void Show()
        {
            Console.WriteLine($"Name: {Name}");
        }

        public void Desc()
        {
            Console.WriteLine($"Description: {Description}");
        }

        public virtual void History() {}
    }
}
