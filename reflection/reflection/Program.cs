using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;

namespace reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type myType = typeof(Salesperson);

            var info = File.ReadAllLines("data.txt");

            List<string> result = new List<string>();

            foreach (var line in info)
            {
                var values = line.Split(',');
                var person = (Salesperson)Activator.CreateInstance(myType);
                var property = typeof(Salesperson).GetProperties();

                property[0].SetValue(person, values[0]); 
                property[1].SetValue(person, DateTime.Parse(values[1]));
                property[2].SetValue(person, decimal.Parse(values[2]));
                property[3].SetValue(person, decimal.Parse(values[3]));
                property[4].SetValue(person, decimal.Parse(values[4]));

                decimal bonus = 0;

                if (person.ActualSales > person.TagetSales)
                {
                    decimal percentOver = (person.ActualSales - person.TagetSales) / person.TagetSales;
                    bonus = person.BasePayment * percentOver;
                }

                var year = DateTime.Now.Year - person.HireDate.Year;
                decimal period_of_service = year * 0.005m * person.BasePayment;

                decimal total = person.BasePayment + bonus + period_of_service;

                result.Add($"Name: {person.Name}, basePayment: {person.BasePayment}, bonus: {bonus}, period_of_service:{period_of_service}, total: {total}");
            }
            File.WriteAllLines("Result.txt", result);
            Console.WriteLine("The data is written to a file");
        }
    }
}
