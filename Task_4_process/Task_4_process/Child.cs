using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_process
{
    class Child
    {
        public static int Run(string[] args)
        {
            string filePath = args[1];
            string word = args[2];

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return -1;
            }

            string text = File.ReadAllText(filePath);

            int count = 0;
            int index = 0;

            while ((index = text.IndexOf(word, index,
                   StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }

            Console.WriteLine(
                $"Слово \"{word}\" встречается {count} раз(а).");

            return 0;
        }
    }
}
