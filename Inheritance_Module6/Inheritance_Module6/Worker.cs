using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Module6
{
    public class Worker
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; }
        public string Post { get; }
        public int Salary { get; set; }

        public Worker(int age, string firstName, string secondName, int salary, string post)
        {
            Age = age;
            FirstName = firstName;
            SecondName = secondName;
            Post = post;
            Salary = salary;
        }

        public virtual void Print() { }

    }
}
