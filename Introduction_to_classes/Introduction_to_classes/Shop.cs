using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_to_classes
{

    public class Shop
    {
        private string name;
        private string address;
        private string profileDescription;
        private string phone;
        private string email;

        public Shop()
        {
            name = "";
            address = "";
            profileDescription = "";
            phone = "";
            email = "";
        }
        public Shop(string Name, string Address, string ProfileDescription, string Phone, string Email)
        {
            name = Name;
            address = Address;
            profileDescription = ProfileDescription;
            phone = Phone;
            email = Email;
        }
        public void Input()
        {
           
            Console.Write("Store Name: ");
            name = Console.ReadLine();

            Console.Write("Address: ");
            address = Console.ReadLine();

            Console.Write("Profile Description: ");
            profileDescription = Console.ReadLine();

            Console.Write("Contact phone number: ");
            phone = Console.ReadLine();

            Console.Write("Contact e-mail: ");
            email = Console.ReadLine();
        }
        public void Print()
        {
            Console.WriteLine("\nStore Information");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Profile: {profileDescription}");
            Console.WriteLine($"Phone: {phone}");
            Console.WriteLine($"E-mail: {email}");
        }

        public string GetName() => name;
        public string GetAddress() => address;
        public string GetProfileDescription() => profileDescription;
        public string GetPhone() => phone;
        public string GetEmail() => email;

        public void SetName(string Name) => name = Name;
        public void SetAddress(string Address) => address = Address;
        public void SetProfileDescription(string Description) => profileDescription = Description;
        public void SetPhone(string Phone) => phone = Phone;
        public void SetEmail(string Email) => email = Email;
    }
}

