using System;
using System.IO;
using System.Text.RegularExpressions;


namespace Password
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName = "password.txt";

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@_-])[A-Za-z\d$@_-]+$");
            string[] text = File.ReadAllLines(fileName);
            
            string resultFolder = "Result";
            if (!Directory.Exists(resultFolder))
            {
                Directory.CreateDirectory(resultFolder);
            }

            string resultFileName = "good_passwords.txt";
            string filePath = Path.Combine(resultFolder, resultFileName);

            foreach (var s in text)
            {
                if (regex.IsMatch(s))
                {
                    File.AppendAllText(filePath, s + Environment.NewLine);
                    Console.WriteLine("The password is written in a file");
                }
            } 
           
        }
    }
}
