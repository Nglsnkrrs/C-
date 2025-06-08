using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Time_before_the_specified_date
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Рассчитать_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(textBox_Date.Text, out DateTime targetDate))
            {
                MessageBox.Show("Введите корректную дату (например, 08.06.2030)", "Ошибка");
                return;
            }

            DateTime now = DateTime.Now;
            if (targetDate <= now)
            {
                textBox_result.Text = "Указанная дата уже прошла.";
                return;
            }

            TimeSpan span = targetDate - now;

            if (radioButton_Second.Checked)
            {
                textBox_result.Text = $"Осталось {span.TotalSeconds:N0} секунд.";
            }
            else if (radioButton_Minutes.Checked)
            {
                textBox_result.Text = $"Осталось {span.TotalMinutes:N0} минут.";
            }
            else if (radioButton_Days.Checked)
            {
                textBox_result.Text = $"Осталось {span.TotalDays:N1} дней.";
            }
            else if (radioButton_Months.Checked)
            {
                double months = span.TotalDays / 30.44; 
                textBox_result.Text = $"Осталось ~{months:N2} месяцев.";
            }
            else if (radioButton_Year.Checked)
            {
                double years = span.TotalDays / 365.25; 
                textBox_result.Text = $"Осталось ~{years:N2} лет.";
            }
        }

        private void radioButton_Second_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

