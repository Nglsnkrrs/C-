using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Quiz
{
    public class Add_user
    {

        public bool Register(string login, string password, string dateOfBirth)
        {
            if (!File.Exists("DataUser.txt"))
            {
                File.Create("DataUser.txt").Close();
            }
            var allUserData = File.ReadAllLines("DataUser.txt");
            foreach (string line in allUserData)
            {
                string[] parts = line.Split('-', 3);
                if (parts[0].Equals(login))
                {
                    Console.WriteLine("Пользователь уже зарегистрирован");
                    return false;
                }
            }
            string result = $"{login}-{password}-{dateOfBirth}";
            File.AppendAllText("DataUser.txt", result + Environment.NewLine);

            Console.WriteLine("Регистрация прошла успешно!");
            return true;
        }

        public bool UserLogin(string login, string password, string dateOfBirth)
        {
            if (!File.Exists("DataUser.txt"))
            {
                File.Create("DataUser.txt").Close();
            }
            List<string> allUserData = File.ReadAllLines("DataUser.txt").ToList();
            foreach (string line in allUserData)
            {
                string[] parts = line.Split('-', 3);
                if (parts[0] == login && parts[1] == password && parts[2] == dateOfBirth)
                {
                    Console.WriteLine("Вход выполнен успешно");
                    return true;
                }
            }
            Console.WriteLine("Неверный логин или пароль");
            return false;
        }

    }
}
