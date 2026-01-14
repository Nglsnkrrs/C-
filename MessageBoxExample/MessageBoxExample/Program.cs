using System;
using System.Runtime.InteropServices;

namespace MessageBoxExample
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        static void Main(string[] args)
        {
            MessageBox(IntPtr.Zero, "Меня зовут Валерия", "Информация", 0);

            MessageBox(IntPtr.Zero, "Мне 21 год", "Информация", 0);

            MessageBox(IntPtr.Zero, "Я программист", "Информация", 0);

            MessageBox(IntPtr.Zero, "Мое хобби — программирование и чтение", "Информация", 0);
        }
    }
}
