using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Operator_overload
{
    public class Magazine
    {
        public string Name { get; set; }
        public int YearFounded {  get; set; }
        public string Description { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public int EmployeeCount { get; set; }

        public Magazine(string name, int yearFounded, string description,
            string contactPhone, string contactEmail, int employeeCount)
        {
            Name = name;
            YearFounded = yearFounded;
            Description = description;
            ContactPhone = contactPhone;
            ContactEmail = contactEmail;
            EmployeeCount = employeeCount;
        }

        public void Info()
        {
            Console.Write("Enter the name of the magazine: ");
            Name = Console.ReadLine();

            Console.Write("Enter the year of foundation: ");
            YearFounded = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a description of the log: ");
            Description = Console.ReadLine();

            Console.Write("Enter your contact phone number: ");
            ContactPhone = Console.ReadLine();

            Console.Write("Enter the contact e-mail: ");
            ContactEmail = Console.ReadLine();
            Console.Write("Count employee: ");
            EmployeeCount = Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine("\nInformation about the magazine:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Year of foundation: {YearFounded}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Contact phone number: {ContactPhone}");
            Console.WriteLine($"Contact e-mail: {ContactEmail}");
            Console.WriteLine($"Count employee: {EmployeeCount}");
        }

        public static Magazine operator +(Magazine mag, int count)
        {
            mag.EmployeeCount += count;
            return mag;
        }
        public static Magazine operator -(Magazine mag, int count)
        {
            mag.EmployeeCount -= count;
            return mag;
        }
        public override bool Equals(object obj)
        {
            if (obj is Magazine other) 
                return this.EmployeeCount == other.EmployeeCount;
            return false;
        }
        public override int GetHashCode()
        {
            return EmployeeCount.GetHashCode();
        }
        public static bool operator ==(Magazine mag1, Magazine mag2)
        {
            return mag1.EmployeeCount.Equals(mag2.EmployeeCount);
        }
        public static bool operator !=(Magazine mag1, Magazine mag2)
        {
            return !(mag1.EmployeeCount == mag2.EmployeeCount);
        }

        public static bool operator <(Magazine mag1, Magazine mag2)
        {
            return mag1.EmployeeCount < mag2.EmployeeCount;
        }

        public static bool operator >(Magazine mag1, Magazine mag2)
        {
            return mag1.EmployeeCount > mag2.EmployeeCount;
        }
    }
}


