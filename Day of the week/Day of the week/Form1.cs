using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Day_of_the_week
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_GetDay_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(textBox_Date.Text, out DateTime date))
            {
                string dayOfWeek = date.ToString("dddd", new CultureInfo("ru-RU"));
                textBox_result.Text = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
            }
            else
            {
                MessageBox.Show("Некорректный формат даты. Введите, например: 08.06.2025", "Ошибка");
            }
        }
    }
}
