using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
            comboBox_Oil.DataSource = fuels;
            comboBox_Oil.DisplayMember = "Name";
            comboBox_Oil.ValueMember = "Price";

            textBox_burgerPrice.Text = "160";
            textBox_ColaPrice.Text = "100";
            textBox_FrrePrice.Text = "120";
            textBox_HotDogPrice.Text = "180";
    
        }


        public class Fuel
        {
            public string Name { get; set; }
            public decimal Price { get; set; }

            public override string ToString() => Name;
        }
 
        List<Fuel> fuels = new List<Fuel>
        {
            new Fuel { Name = "А-95", Price = 52.0m },
            new Fuel { Name = "А-92", Price = 49.0m },
            new Fuel { Name = "ДТ", Price = 50.0m } 
        };
        private  List<decimal> sum = new List<decimal>();
        private void comboBox_Oil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Oil.SelectedItem is Fuel selectfuels)
            {
                textBox_Price.Text = selectfuels.Price.ToString();
            }
        }

        private void radioButtonChecked(object sender, EventArgs e)
        {
            if (radioButton_count.Checked)
            {
                textBox_count.ReadOnly = false;
                textBox_sum.ReadOnly = true;
                textBox_sum.Clear();
            }
            else
            {
                textBox_sum.ReadOnly = false;
                textBox_count.ReadOnly = true;
                textBox_count.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton_count.Checked)
            {
                decimal res = decimal.Parse(textBox_Price.Text) * decimal.Parse(textBox_count.Text);
                label_allSum.Text = res.ToString();
            }
            else 
            {
                label_allSum.Text = textBox_sum.Text;
            }

        }

        private void checkBox_HotDog_CheckedChanged(object sender, EventArgs e)
        {
            textBox_HotDogCount.ReadOnly = false;
            if (!checkBox_HotDog.Checked)
            {
                textBox_HotDogCount.Clear();
                textBox_HotDogCount.ReadOnly = true;
            }
        }

        private void checkBox_Burger_CheckedChanged(object sender, EventArgs e)
        {
            textBox_burgerCount.ReadOnly = false;
            if (!checkBox_Burger.Checked)
            {
                textBox_burgerCount.Clear();
                textBox_burgerCount.ReadOnly = true;
            }
        }

        private void checkBox_Free_CheckedChanged(object sender, EventArgs e)
        {
            textBox_FreeCount.ReadOnly = false;
            if (!checkBox_Free.Checked)
            {
                textBox_FreeCount.Clear();
                textBox_FreeCount.ReadOnly = true;
            }
        }

        private void checkBox_Cola_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ColaCount.ReadOnly = false;
            if (!checkBox_Cola.Checked)
            {
                textBox_ColaCount.Clear();
                textBox_ColaCount.ReadOnly = true;
            }
        }

        private void button_allCafeSum_Click(object sender, EventArgs e)
        {
            decimal res = 0;

            if (checkBox_Burger.Checked && int.TryParse(textBox_burgerCount.Text, out int burgerQty))
                res += decimal.Parse(textBox_burgerPrice.Text) * burgerQty;

            if (checkBox_Cola.Checked && int.TryParse(textBox_ColaCount.Text, out int colaQty))
                res += decimal.Parse(textBox_ColaPrice.Text) * colaQty;

            if (checkBox_Free.Checked && int.TryParse(textBox_FreeCount.Text, out int freeQty))
                res += decimal.Parse(textBox_FrrePrice.Text) * freeQty;

            if (checkBox_HotDog.Checked && int.TryParse(textBox_HotDogCount.Text, out int hotDogQty))
                res += decimal.Parse(textBox_HotDogPrice.Text) * hotDogQty;

            label_allSumcafe.Text = res.ToString();
        }

        private void button_AllSumBestOil_Click(object sender, EventArgs e)
        {
            decimal res = decimal.Parse(label_allSum.Text) + decimal.Parse(label_allSumcafe.Text);
            label_Sum.Text = res.ToString();
        }

        private async void button_pay_Click(object sender, EventArgs e)
        {
            decimal resultSum = 0;
            if (label_Sum.Text != "")
            {
                DialogResult result = MessageBox.Show(
                    "Очистить форму?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    resultSum = decimal.Parse(label_Sum.Text);
                    sum.Add(resultSum);
                    ResetForm();
                    this.TopMost = true;
                }
                else
                {
                    ToggleControls(false); 
                    await Task.Delay(10000); 
                    ToggleControls(true); 
                }
                     
            }
            else { MessageBox.Show($"Сперва рассчитайте сумму к оплате", "Ошибка"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal result = sum.Sum();
            sum.Clear();
            MessageBox.Show($"Итоговая сумма за день: {result:0.00}", "Отчет");
        }

        private void ResetForm()
        {
            label_allSum.Text = "";
            label_allSumcafe.Text = "";
            label_Sum.Text = "";

            textBox_sum.Clear();
            textBox_count.Clear();

            radioButton_count.Checked = false;
            radioButton_sum.Checked = false;

            textBox_count.ReadOnly = true;
            textBox_sum.ReadOnly = true;

            checkBox_Free.Checked = false;
            checkBox_Burger.Checked = false;
            checkBox_Cola.Checked = false;
            checkBox_HotDog.Checked = false;

            textBox_HotDogCount.Clear();
            textBox_burgerCount.Clear();
            textBox_ColaCount.Clear();
            textBox_FreeCount.Clear();

            textBox_HotDogCount.ReadOnly = true;
            textBox_burgerCount.ReadOnly = true;
            textBox_ColaCount.ReadOnly = true;
            textBox_FreeCount.ReadOnly = true;
        }

        private void ToggleControls(bool state)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = state;
            }

            this.Enabled = true;
        }
    }
}
