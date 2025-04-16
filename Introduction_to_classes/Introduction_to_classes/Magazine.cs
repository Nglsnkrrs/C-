using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_to_classes
{
    public class Magazine
    {
        private string name;
        private int yearFounded;
        private string description;
        private string contactPhone;
        private string contactEmail;

        public Magazine()
        {
            name = "";
            yearFounded = 0;
            description = "";
            contactPhone = "";
            contactEmail = "";
        }

        public Magazine(string Name, int YearFounded, string Description, string ContactPhone, string ContactEmail)
        {
            name = Name;
            yearFounded = YearFounded;
            description = Description;
            contactPhone = ContactPhone;
            contactEmail = ContactEmail;
        }
        public void Info()
        {
            Console.Write("Enter the name of the magazine: ");
            name = Console.ReadLine();

            Console.Write("Enter the year of foundation: ");
            while (!int.TryParse(Console.ReadLine(), out yearFounded))
            {
                Console.Write("Mistake! Enter the correct year: ");
            }

            Console.Write("Enter a description of the log: ");
            description = Console.ReadLine();

            Console.Write("Enter your contact phone number: ");
            contactPhone = Console.ReadLine();

            Console.Write("Enter the contact e-mail: ");
            contactEmail = Console.ReadLine();
        }

        public void Print()
        {
            Console.WriteLine("\nInformation about the magazine:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Year of foundation: {yearFounded}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Contact phone number: {contactPhone}");
            Console.WriteLine($"Contact e-mail: {contactEmail}");
        }

        public string GetName() => name;
        public void SetName(string Name) => name = Name;

        public int GetYearFounded() => yearFounded;
        public void SetYearFounded(int YearFounded) => yearFounded = YearFounded;

        public string GetDescription() => description;
        public void SetDescription(string Description) => description = Description;

        public string GetContactPhone() => contactPhone;
        public void SetContactPhone(string ContactPhone) => contactPhone = ContactPhone;

        public string GetContactEmail() => contactEmail;
        public void SetContactEmail(string ContactEmail) => contactEmail = ContactEmail;
    }

    
}
