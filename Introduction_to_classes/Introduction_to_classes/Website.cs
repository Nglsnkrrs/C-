using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Introduction_to_classes {

    public class Website
    {
        private string name;
        private string url;
        private string description;
        private string ipAddress;
        public Website()
        {
            name = "";
            url = "";
            description = "";
            ipAddress = "";
        }

        public Website(string Name, string Url, string Description, string IpAddress)
        {
            name = Name;
            url = Url;
            description = Description;
            ipAddress = IpAddress;
        }

        public void InputInfo()
        {
            Console.Write("Enter the site name: ");
            name = Console.ReadLine();

            Console.Write("Enter the path to the site (URL): ");
            url = Console.ReadLine();

            Console.Write("Enter the site description: ");
            description = Console.ReadLine();

            Console.Write("Enter the IP address of the website: ");
            ipAddress = Console.ReadLine();
        }

        public void PrintInfo()
        {
            Console.WriteLine("\nInformation about the website:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"URL: {url}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"IP-address: {ipAddress}");
        }

    
        public string GetName() => name;
        public void SetName(string Name) => name = Name;

        public string GetUrl() => url;
        public void SetUrl(string Url) => url = Url;

        public string GetDescription() => description;
        public void SetDescription(string Description) => description = Description;

        public string GetIpAddress() => ipAddress;
        public void SetIpAddress(string IpAddress) => ipAddress = IpAddress;
    }


}
