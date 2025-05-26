using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string[] messages = new string[]
        {
            "Имя: Тернавская Валерия\nВозраст: 20 лет",
            "Обучение на курсах в Академии TOP, КФУ им.Вернадского: \nОпыт: 2 года C++, 6 мес. C#, 6 мес. HTML",
            "Навыки: C#, WinForms, C++, HTML + CSS, Python\nУвлечения: гитра, рисование"
        };

            int totalChars = 0;

            for (int i = 0; i < messages.Length; i++)
            {
                totalChars += messages[i].Length;

                if (i == messages.Length - 1)
                {
                    double avg = (double)totalChars / messages.Length;
                    MessageBox.Show(messages[i], $"Среднее: {Math.Round(avg)} символов");
                }
                else
                {
                    MessageBox.Show(messages[i], $"Страница {i + 1}");
                }
            }
        }
    }
}
