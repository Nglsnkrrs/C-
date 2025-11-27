using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Vegetables_and_fruits
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private bool isConnected = false;
        private SqlConnection _connection;
        public Form1()
        {
            InitializeComponent();
            InitializeConnectionString();
        }

        private void InitializeConnectionString()
        {
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Vegetables and Fruits.mdf;Integrated Security=True;Connect Timeout=30";
        }
        private bool CheckingTheConnection()
        {
            if (!isConnected)
            {
                MessageBox.Show("Сначала установите подключение к базе данных!", "Внимание",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SelectQuery(string query)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Connection_btn_Click(object sender, EventArgs e)
        {
            if (_connection?.State == ConnectionState.Open)
            {
                _connection.Close();
            }

            try
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();

                isConnected = true;
                MessageBox.Show("Подключение к базе данных успешно установлено!", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                isConnected = false;
                _connection?.Dispose();
                _connection = null;

                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allInfo_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;
            string allView = "SELECT * FROM info";

            SelectQuery(allView);
        }

        private void allName_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            string allName = "SELECT [Name] FROM info";

            SelectQuery(allName);
        }

        private void allColor_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;
            string allColor = "SELECT [Color] FROM info";
            SelectQuery(allColor);

        }

        private void maxCalories_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;
            try
            {
                string query = "SELECT MAX(Calorie) AS MaxCalories FROM info";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal maxCalories = Convert.ToDecimal(result);

                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("Максимальная калорийность", typeof(string));

                            DataRow row = dataTable.NewRow();
                            row["Максимальная калорийность"] = $"{maxCalories} ккал";
                            dataTable.Rows.Add(row);
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Данные о калорийности не найдены", "Информация",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении максимальной калорийности:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void minCalories_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            try
            {
                string query = "SELECT MIN(Calorie) AS MinCalories FROM info";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal minCalories = Convert.ToDecimal(result);

                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("Максимальная калорийность", typeof(string));

                            DataRow row = dataTable.NewRow();
                            row["Максимальная калорийность"] = $"{minCalories} ккал";
                            dataTable.Rows.Add(row);
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Данные о калорийности не найдены", "Информация",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении максимальной калорийности:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void avgCalories_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            try
            {
                string query = "SELECT AVG(Calorie) AS AverageCalories FROM info";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal avgCalories = Convert.ToDecimal(result);
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("Средняя калорийность", typeof(string));

                            DataRow row = dataTable.NewRow();
                            row["Средняя калорийность"] = $"{avgCalories:F2} ккал";
                            dataTable.Rows.Add(row);
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Данные о калорийности не найдены", "Информация",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении средней калорийности:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vagetablesCount_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            try
            {
                string query = "SELECT COUNT(*) AS Count FROM info WHERE Type = 'Vegetables'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar();

                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("Type", typeof(string));
                        dataTable.Columns.Add("Count", typeof(int));
                        dataTable.Rows.Add("Vegetables", count);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fruitsCount_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            try
            {
                string query = "SELECT COUNT(*) AS Count FROM info WHERE Type = 'Fruit'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar();

                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("Tyoe", typeof(string));
                        dataTable.Columns.Add("Count", typeof(int));
                        dataTable.Rows.Add("Fruits", count);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void colorCount_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;
            using (Form inputForm = new Form())
            {
                inputForm.Text = "Введите цвет";
                inputForm.Size = new Size(300, 150);
                inputForm.StartPosition = FormStartPosition.CenterParent;

                TextBox textBox = new TextBox() { Left = 20, Top = 20, Width = 240 };
                Button okButton = new Button() { Text = "OK", Left = 20, Top = 60, Width = 100 };
                Button cancelButton = new Button() { Text = "Отмена", Left = 140, Top = 60, Width = 100 };

                okButton.DialogResult = DialogResult.OK;
                cancelButton.DialogResult = DialogResult.Cancel;

                inputForm.Controls.AddRange(new Control[] { textBox, okButton, cancelButton });
                inputForm.AcceptButton = okButton;
                inputForm.CancelButton = cancelButton;

                if (inputForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(textBox.Text))
                {
                    string color = textBox.Text;

                    if (string.IsNullOrEmpty(color)) return;

                    try
                    {
                        string query = @"
                        SELECT 
                            Type AS Тип,
                            COUNT(*) AS Count
                        FROM info 
                        WHERE Color = @Color
                        GROUP BY Type";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Color", color);

                                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                                {
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);

                                    if (dataTable.Rows.Count > 0)
                                    {
                                        dataGridView1.DataSource = dataTable;
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Продукты цвета '{color}' не найдены", "Информация",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void colorsCount_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            try
            {
                string query = @"
                SELECT 
                    Color AS Color,
                    Type AS Type,
                    COUNT(*) AS Count
                FROM info 
                GROUP BY Color, Type
                ORDER BY Color, Type";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnection_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_connection?.State == ConnectionState.Open)
                {
                    _connection.Close();
                    _connection.Dispose();
                    _connection = null;

                    isConnected = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    MessageBox.Show("Подключение к базе данных закрыто!", "Информация",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Подключение уже закрыто или не было установлено!", "Информация",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отключении от базы данных:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private decimal? GetNumericInput(string title, string prompt)
        {
            using (Form inputForm = new Form())
            {
                inputForm.Text = title;
                inputForm.Size = new Size(300, 150);
                inputForm.StartPosition = FormStartPosition.CenterParent;

                Label label = new Label() { Text = prompt, Left = 20, Top = 10, Width = 240 };
                TextBox textBox = new TextBox() { Left = 20, Top = 30, Width = 240 };
                Button okButton = new Button() { Text = "OK", Left = 20, Top = 70, Width = 100 };
                Button cancelButton = new Button() { Text = "Отмена", Left = 140, Top = 70, Width = 100 };

                okButton.DialogResult = DialogResult.OK;
                cancelButton.DialogResult = DialogResult.Cancel;

                inputForm.Controls.AddRange(new Control[] { label, textBox, okButton, cancelButton });
                inputForm.AcceptButton = okButton;
                inputForm.CancelButton = cancelButton;

                if (inputForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(textBox.Text))
                {
                    if (decimal.TryParse(textBox.Text, out decimal result))
                    {
                        return result;
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное числовое значение!", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return null;
            }
        }
        private void LowCalories_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            var maxCalories = GetNumericInput("Поиск по калорийности", "Введите максимальную калорийность:");
            if (maxCalories == null) return;

            try
            {
                string query = @"
                SELECT 
                    Name AS Name,
                    Type AS Type,
                    Color AS Color,
                    Calorie AS Calories
                FROM info 
                WHERE Calorie < @MaxCalories
                ORDER BY Calorie DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaxCalories", maxCalories);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable;
                                MessageBox.Show($"Найдено {dataTable.Rows.Count} продуктов с калорийностью ниже {maxCalories}", "Результат",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Продукты с калорийностью ниже {maxCalories} не найдены", "Информация",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighCalories_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            var minCalories = GetNumericInput("Поиск по калорийности", "Введите минимальную калорийность:");
            if (minCalories == null) return;

            try
            {
                string query = @"
                SELECT 
                    Name AS Name,
                    Type AS Type,
                    Color AS Color,
                    Calorie AS Calories
                FROM info 
                WHERE Calorie > @MinCalories
                ORDER BY Calorie ASC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MinCalories", minCalories);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable;
                                MessageBox.Show($"Найдено {dataTable.Rows.Count} продуктов с калорийностью выше {minCalories}", "Результат",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Продукты с калорийностью выше {minCalories} не найдены", "Информация",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RangeCalories_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            var minCalories = GetNumericInput("Диапазон калорийности", "Введите минимальную калорийность:");
            if (minCalories == null) return;

            var maxCalories = GetNumericInput("Диапазон калорийности", "Введите максимальную калорийность:");
            if (maxCalories == null) return;

            if (minCalories >= maxCalories)
            {
                MessageBox.Show("Минимальная калорийность должна быть меньше максимальной!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = @"
                SELECT 
                    Name AS Name,
                    Type AS Type,
                    Color AS Color,
                    Calorie AS Calories
                FROM info 
                WHERE Calorie BETWEEN @MinCalories AND @MaxCalories
                ORDER BY Calorie ASC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MinCalories", minCalories);
                        command.Parameters.AddWithValue("@MaxCalories", maxCalories);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable;
                                MessageBox.Show($"Найдено {dataTable.Rows.Count} продуктов в диапазоне {minCalories}-{maxCalories} калорий", "Результат",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Продукты в диапазоне {minCalories}-{maxCalories} калорий не найдены", "Информация",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void YellowRedColor_btn_Click(object sender, EventArgs e)
        {
            if (!CheckingTheConnection()) return;

            try
            {
                string query = @"
                SELECT 
                    Name AS Name,
                    Type AS Type,
                    Color AS Color,
                    Calorie AS Calories
                FROM info 
                WHERE Color IN ('Yellow', 'Red', 'Yellow', 'Red')
                ORDER BY Color, Name";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable;
                                MessageBox.Show($"Найдено {dataTable.Rows.Count} продуктов желтого или красного цвета", "Результат",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Продукты желтого или красного цвета не найдены", "Информация",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
