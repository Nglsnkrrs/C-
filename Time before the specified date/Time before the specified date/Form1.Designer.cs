namespace Time_before_the_specified_date
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Date = new System.Windows.Forms.TextBox();
            this.radioButton_Year = new System.Windows.Forms.RadioButton();
            this.radioButton_Months = new System.Windows.Forms.RadioButton();
            this.radioButton_Days = new System.Windows.Forms.RadioButton();
            this.radioButton_Minutes = new System.Windows.Forms.RadioButton();
            this.radioButton_Second = new System.Windows.Forms.RadioButton();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.Рассчитать = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Date
            // 
            this.textBox_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.textBox_Date.Location = new System.Drawing.Point(303, 59);
            this.textBox_Date.Name = "textBox_Date";
            this.textBox_Date.Size = new System.Drawing.Size(280, 45);
            this.textBox_Date.TabIndex = 0;
            // 
            // radioButton_Year
            // 
            this.radioButton_Year.AutoSize = true;
            this.radioButton_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.radioButton_Year.Location = new System.Drawing.Point(22, 41);
            this.radioButton_Year.Name = "radioButton_Year";
            this.radioButton_Year.Size = new System.Drawing.Size(93, 43);
            this.radioButton_Year.TabIndex = 1;
            this.radioButton_Year.TabStop = true;
            this.radioButton_Year.Text = "Год";
            this.radioButton_Year.UseVisualStyleBackColor = true;
            // 
            // radioButton_Months
            // 
            this.radioButton_Months.AutoSize = true;
            this.radioButton_Months.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.radioButton_Months.Location = new System.Drawing.Point(22, 90);
            this.radioButton_Months.Name = "radioButton_Months";
            this.radioButton_Months.Size = new System.Drawing.Size(137, 43);
            this.radioButton_Months.TabIndex = 2;
            this.radioButton_Months.TabStop = true;
            this.radioButton_Months.Text = "Месяц";
            this.radioButton_Months.UseVisualStyleBackColor = true;
            // 
            // radioButton_Days
            // 
            this.radioButton_Days.AutoSize = true;
            this.radioButton_Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.radioButton_Days.Location = new System.Drawing.Point(22, 139);
            this.radioButton_Days.Name = "radioButton_Days";
            this.radioButton_Days.Size = new System.Drawing.Size(117, 43);
            this.radioButton_Days.TabIndex = 3;
            this.radioButton_Days.TabStop = true;
            this.radioButton_Days.Text = "День";
            this.radioButton_Days.UseVisualStyleBackColor = true;
            // 
            // radioButton_Minutes
            // 
            this.radioButton_Minutes.AutoSize = true;
            this.radioButton_Minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.radioButton_Minutes.Location = new System.Drawing.Point(22, 188);
            this.radioButton_Minutes.Name = "radioButton_Minutes";
            this.radioButton_Minutes.Size = new System.Drawing.Size(153, 43);
            this.radioButton_Minutes.TabIndex = 4;
            this.radioButton_Minutes.TabStop = true;
            this.radioButton_Minutes.Text = "Минута";
            this.radioButton_Minutes.UseVisualStyleBackColor = true;
            // 
            // radioButton_Second
            // 
            this.radioButton_Second.AutoSize = true;
            this.radioButton_Second.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.radioButton_Second.Location = new System.Drawing.Point(22, 237);
            this.radioButton_Second.Name = "radioButton_Second";
            this.radioButton_Second.Size = new System.Drawing.Size(171, 43);
            this.radioButton_Second.TabIndex = 5;
            this.radioButton_Second.TabStop = true;
            this.radioButton_Second.Text = "Секунда";
            this.radioButton_Second.UseVisualStyleBackColor = true;
            this.radioButton_Second.CheckedChanged += new System.EventHandler(this.radioButton_Second_CheckedChanged);
            // 
            // textBox_result
            // 
            this.textBox_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.textBox_result.Location = new System.Drawing.Point(303, 171);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.Size = new System.Drawing.Size(280, 45);
            this.textBox_result.TabIndex = 6;
            // 
            // Рассчитать
            // 
            this.Рассчитать.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Рассчитать.Location = new System.Drawing.Point(356, 244);
            this.Рассчитать.Name = "Рассчитать";
            this.Рассчитать.Size = new System.Drawing.Size(179, 75);
            this.Рассчитать.TabIndex = 7;
            this.Рассчитать.Text = "Рассчитать";
            this.Рассчитать.UseVisualStyleBackColor = true;
            this.Рассчитать.Click += new System.EventHandler(this.Рассчитать_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(325, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите дату";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Рассчитать);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.radioButton_Second);
            this.Controls.Add(this.radioButton_Minutes);
            this.Controls.Add(this.radioButton_Days);
            this.Controls.Add(this.radioButton_Months);
            this.Controls.Add(this.radioButton_Year);
            this.Controls.Add(this.textBox_Date);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Date;
        private System.Windows.Forms.RadioButton radioButton_Year;
        private System.Windows.Forms.RadioButton radioButton_Months;
        private System.Windows.Forms.RadioButton radioButton_Days;
        private System.Windows.Forms.RadioButton radioButton_Minutes;
        private System.Windows.Forms.RadioButton radioButton_Second;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Button Рассчитать;
        private System.Windows.Forms.Label label1;
    }
}

