using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Admin
    {
        public void CreateQuiz()
        {
            Console.Write("Введите название файла викторины: ");
            string fileName = Console.ReadLine() + ".txt";
            List<string> quizContent = new List<string>();

            while (true)
            {
                Console.Write("\nВведите вопрос (или пустую строку для завершения): ");
                string question = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(question)) break;

                Console.WriteLine("Введите 4 варианта ответа через запятую:");
                string answers = Console.ReadLine();

                Console.WriteLine("Введите правильные ответы (как текст из вариантов, через запятую):");
                string correct = Console.ReadLine();

                quizContent.Add(question);
                quizContent.Add(answers);
                quizContent.Add(correct);
            }

            File.WriteAllLines(fileName, quizContent);
            Console.WriteLine("Викторина успешно сохранена.");
        }

        static void EditQuiz()
        {
            Console.Write("Введите название файла викторины: ");
            string fileName = Console.ReadLine() + ".txt";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            var lines = new List<string>(File.ReadAllLines(fileName));
            for (int i = 0; i < lines.Count; i += 3)
            {
                Console.WriteLine($"\nВопрос {i / 3 + 1}: {lines[i]}");
                Console.WriteLine($"Варианты: {lines[i + 1]}");
                Console.WriteLine($"Ответы: {lines[i + 2]}");

                Console.WriteLine("Хотите изменить этот вопрос? (yes/no)");
                if (Console.ReadLine() == "yes")
                {
                    Console.Write("Новый вопрос: ");
                    lines[i] = Console.ReadLine();

                    Console.Write("Новые варианты ответа через запятую: ");
                    lines[i + 1] = Console.ReadLine();

                    Console.Write("Новые правильные ответы через запятую: ");
                    lines[i + 2] = Console.ReadLine();
                }
            }

            File.WriteAllLines(fileName, lines);
            Console.WriteLine("Изменения сохранены.");
        }

        static void ListQuizzes()
        {
            Console.WriteLine("Список викторин:");
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            foreach (var file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        static void DeleteQuiz()
        {
            Console.Write("Введите имя викторины для удаления (без .txt): ");
            string name = Console.ReadLine() + ".txt";
            if (File.Exists(name))
            {
                File.Delete(name);
                Console.WriteLine("Файл удалён.");
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }

        public void AdminProf()
        {
            while (true)
            {
                const string adminLogin = "admin";
                const string adminPassword = "admin";

                Console.Write("Введите логин администратора: ");
                string login = Console.ReadLine();

                Console.Write("Введите пароль администратора: ");
                string password = Console.ReadLine();

                if (login != adminLogin || password != adminPassword)
                {
                    Console.WriteLine("Неверные данные!");
                    return;
                }
                Console.WriteLine("\n--- Утилита викторин ---");
                Console.WriteLine("1. Создать новую викторину");
                Console.WriteLine("2. Редактировать существующую викторину");
                Console.WriteLine("3. Просмотреть список викторин");
                Console.WriteLine("4. Удалить викторину");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите пункт: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: CreateQuiz(); break;
                    case 2: EditQuiz(); break;
                    case 3: ListQuizzes(); break;
                    case 4: DeleteQuiz(); break;
                    case 5: return;
                    default: Console.WriteLine("Неверный ввод."); break;
                }
            }
        }
    }

    }
}

    

