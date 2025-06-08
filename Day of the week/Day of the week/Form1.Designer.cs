namespace Day_of_the_week
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
            this.button_GetDay = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Date
            // 
            this.textBox_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.textBox_Date.Location = new System.Drawing.Point(324, 23);
            this.textBox_Date.Name = "textBox_Date";
            this.textBox_Date.Size = new System.Drawing.Size(288, 45);
            this.textBox_Date.TabIndex = 0;
            // 
            // button_GetDay
            // 
            this.button_GetDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button_GetDay.Location = new System.Drawing.Point(324, 223);
            this.button_GetDay.Name = "button_GetDay";
            this.button_GetDay.Size = new System.Drawing.Size(288, 74);
            this.button_GetDay.TabIndex = 1;
            this.button_GetDay.Text = "Получить день недели";
            this.button_GetDay.UseVisualStyleBackColor = true;
            this.button_GetDay.Click += new System.EventHandler(this.button_GetDay_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.textBox_result.Location = new System.Drawing.Point(324, 122);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.Size = new System.Drawing.Size(288, 45);
            this.textBox_result.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите дату";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.Location = new System.Drawing.Point(24, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "День недели";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 359);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.button_GetDay);
            this.Controls.Add(this.textBox_Date);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Date;
        private System.Windows.Forms.Button button_GetDay;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

