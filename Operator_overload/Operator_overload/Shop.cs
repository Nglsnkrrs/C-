using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Operator_overload
{
    public class Shop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ProfileDescription { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Square { get; set; }

        public Shop(string name, string address, string profileDescription, string phone, string email, double square)
        {
            Name = name;
            Address = address;
            ProfileDescription = profileDescription;
            Phone = phone;
            Email = email;
            Square = square;
        }
        public void Input()
        {

            Console.Write("Store Name: ");
            Name = Console.ReadLine();

            Console.Write("Address: ");
            Address = Console.ReadLine();

            Console.Write("Profile Description: ");
            ProfileDescription = Console.ReadLine();

            Console.Write("Contact phone number: ");
            Phone = Console.ReadLine();

            Console.Write("Contact e-mail: ");
            Email = Console.ReadLine();

            Console.Write("Square: ");
            Square = Convert.ToDouble(Console.ReadLine());
        }
        public void Print()
        {
            Console.WriteLine("\nStore Information");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Profile: {ProfileDescription}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"E-mail: {Email}");
            Console.WriteLine($"Square: {Square}");
        }
        public static Shop operator +(Shop shop, double count)
        {
            shop.Square += count;
            return shop;
        }
        public static Shop operator -(Shop shop, double count)
        {
            shop.Square -= count;
            return shop;
        }
        public override bool Equals(object obj)
        {
            if (obj is Shop other)
                return this.Square == other.Square;
            return false;
        }
        public override int GetHashCode()
        {
            return Square.GetHashCode();
        }
        public static bool operator ==(Shop shop1, Shop shop2)
        {
            return shop1.Square.Equals(shop2.Square);
        }
        public static bool operator !=(Shop shop1, Shop shop2)
        {
            return !(shop1.Square == shop2.Square);
        }
        public static bool operator <(Shop shop1, Shop shop2)
        {
            return shop1.Square < shop2.Square;
        }
        public static bool operator >(Shop shop1, Shop shop2)
        {
            return shop1.Square > shop2.Square;
        }
    }
}
