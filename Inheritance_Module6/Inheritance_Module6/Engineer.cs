using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Engineer : Worker
    {
        public Engineer(int age, string firstName, string secondName, int salary, string post) : base(age, firstName, secondName, salary, post)
        {
        }

        public override void Print()
        {
            Console.WriteLine("This is an Engineer. He develops and maintains technical systems.");
            Console.WriteLine($"Post: {Post}");
            Console.WriteLine($"FirstName: {FirstName}");
            Console.WriteLine($"secondName: {SecondName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }
}
