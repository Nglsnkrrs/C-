using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using System.Linq;


namespace Password_Linq
{
    public class Program
    {
        static Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@_-])[A-Za-z\d$@_-]+$");

        static void Main(string[] args)
        {
            string fileName = "password.txt";
            string[] text = File.ReadAllLines(fileName);

            string resultFolder = "Result";
            if (!Directory.Exists(resultFolder))
            {
                Directory.CreateDirectory(resultFolder);
            }

            string resultFileName = "good_passwords.txt";
            string filePath = Path.Combine(resultFolder, resultFileName);

            Console.WriteLine("Work LINQ Expression");
            LINQExpression(text, filePath);
            Console.WriteLine("The password is written in a file");

            Console.WriteLine();

            Console.WriteLine("Extension Methods");
            ExtensionMethods(text, filePath);
            Console.WriteLine("The password is written in a file");

        }


        static void LINQExpression(string[] passwords, string filePath)
        {
            string[] result = (from password in passwords
                          where regex.IsMatch(password)
                          select password).ToArray();

            File.AppendAllLines(filePath, result);
        }

        static void ExtensionMethods(string[] passwords, string filePath)
        {
            string[] result = passwords.Where(password => regex.IsMatch(password))
                .Select(password => password)
                .ToArray();

            File.AppendAllLines(filePath, result);
        }
    }
}
