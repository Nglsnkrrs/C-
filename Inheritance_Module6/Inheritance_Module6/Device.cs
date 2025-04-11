using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Device
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Device(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public virtual void Sound() 
        {
            Console.WriteLine("Sound: ");
        }
        public void Show() 
        {
            Console.WriteLine("Name device: " + Name);
        }
        public void Desc() 
        {
            Console.WriteLine($"Description device: {Description}");
        }
    }
}
