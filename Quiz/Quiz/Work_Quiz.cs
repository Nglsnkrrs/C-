using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace Quiz
{
    public class Work_Quiz
    {
        public int SelectTest(string NameTest)
        {
            int score = 0;

            if (!File.Exists(NameTest))
            {
                Console.WriteLine("Файл теста не найден.");
                return score;
            }

            string[] test = File.ReadAllLines(NameTest);
            int totalQuestions = test.Length / 3;
            for (int i = 0; i < totalQuestions; i++)
            {
                string question = test[i * 3];
                string[] answers = test[i * 3 + 1].Split(',').Select(a => a.Trim()).ToArray();
                string[] correctAnswers = test[i * 3 + 2].Split(',').Select(a => a.Trim()).ToArray();

                List<int> correctIndexes = new List<int>();
                for (int j = 0; j < answers.Length; j++)
                {
                    if (correctAnswers.Contains(answers[j]))
                    {
                        correctIndexes.Add(j + 1);
                    }
                }

                Console.WriteLine($"\nВопрос {i + 1}: {question}");
                for (int j = 0; j < answers.Length; j++)
                {
                    Console.WriteLine($"{j + 1}. {answers[j]}");
                }
                Console.Write("Введите номера правильных ответов через запятую (например: 1,3): ");
                string input = Console.ReadLine();
                List<int> userIndexes = input.Split(',')
                                             .Select(s => s.Trim())
                                             .Where(s => int.TryParse(s, out _))
                                             .Select(s => int.Parse(s))
                                             .ToList();
                bool isCorrect = userIndexes.OrderBy(x => x).SequenceEqual(correctIndexes.OrderBy(x => x));
                if (isCorrect)
                {
                    score++;
                    Console.WriteLine("Правильно!");
                }
                else
                {
                    Console.WriteLine("Неверно. Правильные ответы: " + string.Join(", ", correctIndexes));
                }
            }

            Console.WriteLine($"\nВаш итоговый результат: {score} из {totalQuestions}");
            return score;
        }

        public int SelectMixedTest(string[] testFiles)
        {
            var allQuestions = new List<(string Question, string[] Answers, string[] CorrectAnswers)>();

            foreach (var file in testFiles)
            {
                if (!File.Exists(file)) continue;

                string[] lines = File.ReadAllLines(file);
                int count = lines.Length / 3;

                for (int i = 0; i < count; i++)
                {
                    string q = lines[i * 3];
                    string[] a = lines[i * 3 + 1].Split(',').Select(x => x.Trim()).ToArray();
                    string[] c = lines[i * 3 + 2].Split(',').Select(x => x.Trim()).ToArray();

                    allQuestions.Add((q, a, c));
                }
            }

            var rand = new Random();
            allQuestions = allQuestions.OrderBy(_ => rand.Next()).ToList();

            int score = 0;
            for (int i = 0; i < allQuestions.Count; i++)
            {
                var (question, answers, correctAnswers) = allQuestions[i];

                List<int> correctIndexes = new List<int>();
                for (int j = 0; j < answers.Length; j++)
                {
                    if (correctAnswers.Contains(answers[j]))
                        correctIndexes.Add(j + 1);
                }

                Console.WriteLine($"\nВопрос {i + 1}: {question}");
                for (int j = 0; j < answers.Length; j++)
                {
                    Console.WriteLine($"{j + 1}. {answers[j]}");
                }
                Console.Write("Введите номера правильных ответов через запятую (например: 1,3): ");
                string input = Console.ReadLine();
                List<int> userIndexes = input.Split(',')
                                             .Select(s => s.Trim())
                                             .Where(s => int.TryParse(s, out _))
                                             .Select(int.Parse)
                                             .ToList();

                bool isCorrect = userIndexes.OrderBy(x => x).SequenceEqual(correctIndexes.OrderBy(x => x));
                if (isCorrect)
                {
                    score++;
                    Console.WriteLine("Правильно!");
                }
                else
                {
                    Console.WriteLine("Неверно. Правильные ответы: " + string.Join(", ", correctIndexes));
                }
            }

            Console.WriteLine($"\nВаш итоговый результат: {score} из {allQuestions.Count}");
            return score;
        }

        public void RunTheQuiz(string login)
        {
            string result;
            while (true)
            {
                Console.WriteLine("History");
                Console.WriteLine("Geography");
                Console.WriteLine("Biology");
                Console.WriteLine("Mathematics");
                Console.WriteLine("Russian");
                Console.WriteLine("Mixed");
                Console.WriteLine("Back");
                Console.Write("Your choice: ");
                string NameTest = Console.ReadLine();

                switch (NameTest)
                {
                    case "History":
                        {
                            int score = SelectTest(NameTest + ".txt");
                            File.AppendAllText($"{login}.txt", $"{NameTest}-{score}" + Environment.NewLine);
                            File.AppendAllText(NameTest + "_results.txt", $"{login}-{score}" + Environment.NewLine);
                            break;
                        }
                    case "Geography":
                        {
                            int score = SelectTest(NameTest + ".txt");
                            File.AppendAllText($"{login}.txt", $"{NameTest}-{score}" + Environment.NewLine);
                            File.AppendAllText(NameTest + "_results.txt", $"{login}-{score}" + Environment.NewLine);
                            break;
                        }
                    case "Biology":
                        {
                            int score = SelectTest(NameTest + ".txt");
                            File.AppendAllText($"{login}.txt", $"{NameTest}-{score}" + Environment.NewLine);
                            File.AppendAllText(NameTest + "_results.txt", $"{login}-{score}" + Environment.NewLine);
                            break;
                        }
                    case "Mathematics":
                        {
                            int score = SelectTest(NameTest + ".txt");
                            File.AppendAllText($"{login}.txt", $"{NameTest}-{score}" + Environment.NewLine);
                            File.AppendAllText(NameTest + "_results.txt", $"{login}-{score}" + Environment.NewLine);
                            break;
                        }
                    case "Russian":
                        {
                            int score = SelectTest(NameTest + ".txt");
                            File.AppendAllText($"{login}.txt", $"{NameTest}-{score}" + Environment.NewLine);
                            File.AppendAllText(NameTest + "_results.txt", $"{login}-{score}" + Environment.NewLine);
                            break;
                        }
                    case "Mixed":
                        {
                            int score = SelectMixedTest(new string[]
                            {
                               "History.txt", "Geography.txt", "Biology.txt", "Mathematics.txt", "Russian.txt"
                            });

                            File.AppendAllText($"{login}.txt", $"{NameTest}-{score}" + Environment.NewLine);
                            File.AppendAllText("Mixed_results.txt", $"{login}-{score}" + Environment.NewLine);
                            break;
                        }

                    case "Back": return;


                }
                var allResults = File.ReadAllLines(NameTest + "_results.txt")
                    .Select(line =>
                    {
                        string[] parts = line.Split('-');
                        return new { Name = parts[0], Score = int.Parse(parts[1]) };
                    })
                    .OrderByDescending(x => x.Score)
                    .ToList();

                int position = allResults.FindIndex(x => x.Name == login) + 1;

                Console.WriteLine($"Ваше место в таблице: {position} из {allResults.Count}");

            }

        }

        public void YourResultTest(string login)
        {
            string fileName = $"{login}.txt";
            if (File.Exists(fileName))
            {
                var results = File.ReadAllLines(fileName);
                Console.WriteLine($"Результаты тестов пользователя {login}:");
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("Нет сохранённых результатов");
            }
        }

        public void TopResult(string NameTest)
        {
            if (!File.Exists(NameTest))
            {
                Console.WriteLine("Файл с результатами не найден!");
                return;
            }

            int score;
            var results = File.ReadAllLines(NameTest)
                .Select(line =>
                {
                    string[] parts = line.Split('-');
                    int score = int.Parse(parts[1]);
                    return (Name: parts[0], Score: score);
                })
                .Where(x => x.Score >= 0)
                .OrderByDescending(x => x.Score)
                .Take(20)
                .ToList();


            Console.WriteLine($"Топ-20 результатов ({NameTest}):");
            Console.WriteLine("-----------------------------");
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {results[i].Name} — {results[i].Score} баллов");
            }
            Console.WriteLine("-----------------------------");
        }

        public void ChangeDateBandPassword(string login)
        {
            List<string> data = File.ReadAllLines("DataUser.txt").ToList();
            bool userFound = false;

            for (int i = 0; i < data.Count; i++)
            {
                string[] parts = data[i].Split("-", 3);
                if (parts[0].Equals(login))
                {
                    userFound = true;
                    while (true)
                    {
                        Console.WriteLine("1. Изменить пароль");
                        Console.WriteLine("2. Изменить дату рождения");
                        Console.WriteLine("3. Назад");
                        Console.Write("Ваш выбор: ");
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Write("Введите новый пароль: ");
                                string newPassword = Console.ReadLine();
                                parts[1] = newPassword;

                                data[i] = $"{parts[0]}-{parts[1]}-{parts[2]}";
                                Console.WriteLine("Пароль успешно изменен!");
                                break;
                            case 2:
                                Console.Write("Введите новую дату рождения: ");
                                string newDate = Console.ReadLine();
                                parts[2] = newDate;
                                data[i] = $"{parts[0]}-{parts[1]}-{parts[2]}";
                                Console.WriteLine("Дата рождения успешно изменена!");
                                break;
                            case 3: return;

                        }
                        File.WriteAllLines("DataUser.txt", data);
                        Console.WriteLine("Изменения сохранены");
                    }

                }
            }
            if (!userFound)
            {
                Console.WriteLine($"Пользователь с логином '{login}' не найден!");
            }



        }
    }
}
