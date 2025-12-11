using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToEntities
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public double GPA { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student { Name = "Анна", Age = 20, Group = "ПИ-11", GPA = 4.8 },
                new Student { Name = "Борис", Age = 19, Group = "ПИ-11", GPA = 3.5 },
                new Student { Name = "Виктор", Age = 21, Group = "ПИ-12", GPA = 4.2 },
                new Student { Name = "Галина", Age = 20, Group = "ПИ-12", GPA = 5.0 },
                new Student { Name = "Дмитрий", Age = 18, Group = "ПИ-11", GPA = 3.8 }
            };

            Console.WriteLine("Исходный список студентов:");
            Console.WriteLine("---------------------------");
            students.Select((s, i) => $"{i + 1}. {s.Name}, {s.Age} лет, Группа: {s.Group}, Средний балл: {s.GPA}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 1. Студенты с GPA выше 4.0
            Console.WriteLine("1. Студенты с GPA выше 4.0:");
            Console.WriteLine("---------------------------");
            students.Where(s => s.GPA > 4.0)
                    .Select(s => $"{s.Name} (Группа: {s.Group}, GPA: {s.GPA})")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 2. Студенты группы ПИ-11
            Console.WriteLine("2. Студенты группы ПИ-11:");
            Console.WriteLine("--------------------------");
            students.Where(s => s.Group == "ПИ-11")
                    .Select(s => $"{s.Name}, {s.Age} лет, GPA: {s.GPA}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 3. Студенты старше 19 лет
            Console.WriteLine("3. Студенты старше 19 лет:");
            Console.WriteLine("---------------------------");
            students.Where(s => s.Age > 19)
                    .Select(s => $"{s.Name}, {s.Age} лет, Группа: {s.Group}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 4. Сортировка по GPA (по убыванию)
            Console.WriteLine("4. Студенты, отсортированные по GPA (по убыванию):");
            Console.WriteLine("---------------------------------------------------");
            students.OrderByDescending(s => s.GPA)
                    .Select(s => $"{s.Name}: {s.GPA} (Группа: {s.Group})")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 5. Сортировка по имени (по возрастанию)
            Console.WriteLine("5. Студенты, отсортированные по имени:");
            Console.WriteLine("--------------------------------------");
            students.OrderBy(s => s.Name)
                    .Select(s => $"{s.Name} - {s.Group}, {s.Age} лет")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 6. Средний GPA по группам
            Console.WriteLine("6. Средний GPA по группам:");
            Console.WriteLine("--------------------------");
            students.GroupBy(s => s.Group)
                    .Select(g => new
                    {
                        Group = g.Key,
                        AverageGPA = g.Average(s => s.GPA)
                    })
                    .OrderBy(g => g.Group)
                    .Select(g => $"Группа {g.Group}: средний GPA = {g.AverageGPA:F2}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 7. Самый старший студент
            Console.WriteLine("7. Самый старший студент:");
            Console.WriteLine("-------------------------");
            students.OrderByDescending(s => s.Age)
                    .Take(1)
                    .Select(s => $"{s.Name}, {s.Age} лет, Группа: {s.Group}, GPA: {s.GPA}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 8. Самый молодой студент
            Console.WriteLine("8. Самый молодой студент:");
            Console.WriteLine("-------------------------");
            students.OrderBy(s => s.Age)
                    .Take(1)
                    .Select(s => $"{s.Name}, {s.Age} лет, Группа: {s.Group}, GPA: {s.GPA}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 9. Общее количество студентов
            Console.WriteLine("9. Общее количество студентов:");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Всего студентов: {students.Count()}");
            Console.WriteLine();

            // 10. Студент с наивысшим GPA
            Console.WriteLine("10. Студент с наивысшим GPA:");
            Console.WriteLine("----------------------------");
            students.OrderByDescending(s => s.GPA)
                    .Take(1)
                    .Select(s => $"{s.Name} (GPA: {s.GPA}, Группа: {s.Group})")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 11. Студенты с GPA в диапазоне 3.5-4.5
            Console.WriteLine("11. Студенты с GPA в диапазоне 3.5-4.5:");
            Console.WriteLine("----------------------------------------");
            students.Where(s => s.GPA >= 3.5 && s.GPA <= 4.5)
                    .OrderByDescending(s => s.GPA)
                    .Select(s => $"{s.Name}: {s.GPA} (Группа: {s.Group})")
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 12. Средний возраст студентов
            Console.WriteLine("12. Средний возраст студентов:");
            Console.WriteLine("------------------------------");
            var averageAge = students.Average(s => s.Age);
            Console.WriteLine($"Средний возраст: {averageAge:F1} лет");
            Console.WriteLine();

            // 13. Студенты, сгруппированные по группе
            Console.WriteLine("13. Студенты, сгруппированные по группе:");
            Console.WriteLine("----------------------------------------");
            students.GroupBy(s => s.Group)
                    .OrderBy(g => g.Key)
                    .SelectMany(g => new[] { $"Группа {g.Key}:" }
                        .Concat(g.Select(s => $"  {s.Name}, {s.Age} лет, GPA: {s.GPA}")))
                    .ToList()
                    .ForEach(Console.WriteLine);
            Console.WriteLine();

            // 14. Проверка, есть ли отличники (GPA = 5.0)
            Console.WriteLine("14. Есть ли отличники (GPA = 5.0)?");
            Console.WriteLine("----------------------------------");
            var hasExcellentStudents = students.Any(s => s.GPA == 5.0);
            Console.WriteLine(hasExcellentStudents ? "Да, есть отличники!" : "Нет отличников");

            if (hasExcellentStudents)
            {
                students.Where(s => s.GPA == 5.0)
                        .Select(s => $"  {s.Name} из группы {s.Group}")
                        .ToList()
                        .ForEach(Console.WriteLine);
            }
            Console.WriteLine();

            // 15. Список уникальных групп
            Console.WriteLine("15. Список уникальных групп:");
            Console.WriteLine("----------------------------");
            students.Select(s => s.Group)
                    .Distinct()
                    .OrderBy(g => g)
                    .Select((g, i) => $"{i + 1}. {g}")
                    .ToList()
                    .ForEach(Console.WriteLine);
        }
    }
}