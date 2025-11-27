namespace Vegetables_and_fruits
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
            this.Connection_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.allInfo_btn = new System.Windows.Forms.Button();
            this.allName_btn = new System.Windows.Forms.Button();
            this.allColor_btn = new System.Windows.Forms.Button();
            this.maxCalories_btn = new System.Windows.Forms.Button();
            this.minCalories_btn = new System.Windows.Forms.Button();
            this.avgCalories_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorsCount_btn = new System.Windows.Forms.Button();
            this.colorCount_btn = new System.Windows.Forms.Button();
            this.fruitsCount_btn = new System.Windows.Forms.Button();
            this.vagetablesCount_btn = new System.Windows.Forms.Button();
            this.disconnection_btn = new System.Windows.Forms.Button();
            this.LowCalories_btn = new System.Windows.Forms.Button();
            this.HighCalories_btn = new System.Windows.Forms.Button();
            this.RangeCalories_btn = new System.Windows.Forms.Button();
            this.YellowRedColor_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connection_btn
            // 
            this.Connection_btn.Location = new System.Drawing.Point(24, 13);
            this.Connection_btn.Name = "Connection_btn";
            this.Connection_btn.Size = new System.Drawing.Size(123, 38);
            this.Connection_btn.TabIndex = 0;
            this.Connection_btn.Text = "Connection";
            this.Connection_btn.UseVisualStyleBackColor = true;
            this.Connection_btn.Click += new System.EventHandler(this.Connection_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 280);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(774, 370);
            this.dataGridView1.TabIndex = 1;
            // 
            // allInfo_btn
            // 
            this.allInfo_btn.Location = new System.Drawing.Point(10, 19);
            this.allInfo_btn.Name = "allInfo_btn";
            this.allInfo_btn.Size = new System.Drawing.Size(93, 34);
            this.allInfo_btn.TabIndex = 2;
            this.allInfo_btn.Text = "All info";
            this.allInfo_btn.UseVisualStyleBackColor = true;
            this.allInfo_btn.Click += new System.EventHandler(this.allInfo_btn_Click);
            // 
            // allName_btn
            // 
            this.allName_btn.Location = new System.Drawing.Point(131, 19);
            this.allName_btn.Name = "allName_btn";
            this.allName_btn.Size = new System.Drawing.Size(93, 34);
            this.allName_btn.TabIndex = 3;
            this.allName_btn.Text = "All name";
            this.allName_btn.UseVisualStyleBackColor = true;
            this.allName_btn.Click += new System.EventHandler(this.allName_btn_Click);
            // 
            // allColor_btn
            // 
            this.allColor_btn.Location = new System.Drawing.Point(252, 19);
            this.allColor_btn.Name = "allColor_btn";
            this.allColor_btn.Size = new System.Drawing.Size(93, 34);
            this.allColor_btn.TabIndex = 4;
            this.allColor_btn.Text = "All color";
            this.allColor_btn.UseVisualStyleBackColor = true;
            this.allColor_btn.Click += new System.EventHandler(this.allColor_btn_Click);
            // 
            // maxCalories_btn
            // 
            this.maxCalories_btn.Location = new System.Drawing.Point(373, 19);
            this.maxCalories_btn.Name = "maxCalories_btn";
            this.maxCalories_btn.Size = new System.Drawing.Size(93, 34);
            this.maxCalories_btn.TabIndex = 5;
            this.maxCalories_btn.Text = "Max calories";
            this.maxCalories_btn.UseVisualStyleBackColor = true;
            this.maxCalories_btn.Click += new System.EventHandler(this.maxCalories_btn_Click);
            // 
            // minCalories_btn
            // 
            this.minCalories_btn.Location = new System.Drawing.Point(494, 19);
            this.minCalories_btn.Name = "minCalories_btn";
            this.minCalories_btn.Size = new System.Drawing.Size(93, 34);
            this.minCalories_btn.TabIndex = 6;
            this.minCalories_btn.Text = "Min calories";
            this.minCalories_btn.UseVisualStyleBackColor = true;
            this.minCalories_btn.Click += new System.EventHandler(this.minCalories_btn_Click);
            // 
            // avgCalories_btn
            // 
            this.avgCalories_btn.Location = new System.Drawing.Point(615, 19);
            this.avgCalories_btn.Name = "avgCalories_btn";
            this.avgCalories_btn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.avgCalories_btn.Size = new System.Drawing.Size(93, 34);
            this.avgCalories_btn.TabIndex = 7;
            this.avgCalories_btn.Text = "Avg calories";
            this.avgCalories_btn.UseVisualStyleBackColor = true;
            this.avgCalories_btn.Click += new System.EventHandler(this.avgCalories_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.allName_btn);
            this.groupBox1.Controls.Add(this.avgCalories_btn);
            this.groupBox1.Controls.Add(this.allInfo_btn);
            this.groupBox1.Controls.Add(this.minCalories_btn);
            this.groupBox1.Controls.Add(this.allColor_btn);
            this.groupBox1.Controls.Add(this.maxCalories_btn);
            this.groupBox1.Location = new System.Drawing.Point(28, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 67);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Задание 3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.YellowRedColor_btn);
            this.groupBox2.Controls.Add(this.RangeCalories_btn);
            this.groupBox2.Controls.Add(this.HighCalories_btn);
            this.groupBox2.Controls.Add(this.LowCalories_btn);
            this.groupBox2.Controls.Add(this.colorsCount_btn);
            this.groupBox2.Controls.Add(this.colorCount_btn);
            this.groupBox2.Controls.Add(this.fruitsCount_btn);
            this.groupBox2.Controls.Add(this.vagetablesCount_btn);
            this.groupBox2.Location = new System.Drawing.Point(32, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(733, 133);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Задание 4";
            // 
            // colorsCount_btn
            // 
            this.colorsCount_btn.Location = new System.Drawing.Point(548, 19);
            this.colorsCount_btn.Name = "colorsCount_btn";
            this.colorsCount_btn.Size = new System.Drawing.Size(179, 50);
            this.colorsCount_btn.TabIndex = 3;
            this.colorsCount_btn.Text = "Count fruits and vegetables color";
            this.colorsCount_btn.UseVisualStyleBackColor = true;
            this.colorsCount_btn.Click += new System.EventHandler(this.colorsCount_btn_Click);
            // 
            // colorCount_btn
            // 
            this.colorCount_btn.Location = new System.Drawing.Point(363, 19);
            this.colorCount_btn.Name = "colorCount_btn";
            this.colorCount_btn.Size = new System.Drawing.Size(179, 50);
            this.colorCount_btn.TabIndex = 2;
            this.colorCount_btn.Text = "Count color";
            this.colorCount_btn.UseVisualStyleBackColor = true;
            this.colorCount_btn.Click += new System.EventHandler(this.colorCount_btn_Click);
            // 
            // fruitsCount_btn
            // 
            this.fruitsCount_btn.Location = new System.Drawing.Point(178, 19);
            this.fruitsCount_btn.Name = "fruitsCount_btn";
            this.fruitsCount_btn.Size = new System.Drawing.Size(179, 50);
            this.fruitsCount_btn.TabIndex = 1;
            this.fruitsCount_btn.Text = "Count fruints";
            this.fruitsCount_btn.UseVisualStyleBackColor = true;
            this.fruitsCount_btn.Click += new System.EventHandler(this.fruitsCount_btn_Click);
            // 
            // vagetablesCount_btn
            // 
            this.vagetablesCount_btn.Location = new System.Drawing.Point(6, 19);
            this.vagetablesCount_btn.Name = "vagetablesCount_btn";
            this.vagetablesCount_btn.Size = new System.Drawing.Size(179, 50);
            this.vagetablesCount_btn.TabIndex = 0;
            this.vagetablesCount_btn.Text = "Count vegetables";
            this.vagetablesCount_btn.UseVisualStyleBackColor = true;
            this.vagetablesCount_btn.Click += new System.EventHandler(this.vagetablesCount_btn_Click);
            // 
            // disconnection_btn
            // 
            this.disconnection_btn.Location = new System.Drawing.Point(159, 13);
            this.disconnection_btn.Name = "disconnection_btn";
            this.disconnection_btn.Size = new System.Drawing.Size(123, 38);
            this.disconnection_btn.TabIndex = 10;
            this.disconnection_btn.Text = "Disconnect";
            this.disconnection_btn.UseVisualStyleBackColor = true;
            this.disconnection_btn.Click += new System.EventHandler(this.disconnection_btn_Click);
            // 
            // LowCalories_btn
            // 
            this.LowCalories_btn.Location = new System.Drawing.Point(6, 75);
            this.LowCalories_btn.Name = "LowCalories_btn";
            this.LowCalories_btn.Size = new System.Drawing.Size(179, 50);
            this.LowCalories_btn.TabIndex = 4;
            this.LowCalories_btn.Text = "Vegetables and fruits with a lower calorie content than indicated";
            this.LowCalories_btn.UseVisualStyleBackColor = true;
            this.LowCalories_btn.Click += new System.EventHandler(this.LowCalories_btn_Click);
            // 
            // HighCalories_btn
            // 
            this.HighCalories_btn.Location = new System.Drawing.Point(191, 75);
            this.HighCalories_btn.Name = "HighCalories_btn";
            this.HighCalories_btn.Size = new System.Drawing.Size(179, 50);
            this.HighCalories_btn.TabIndex = 5;
            this.HighCalories_btn.Text = "Vegetables and fruits with a HIGHER calorie content than indicated";
            this.HighCalories_btn.UseVisualStyleBackColor = true;
            this.HighCalories_btn.Click += new System.EventHandler(this.HighCalories_btn_Click);
            // 
            // RangeCalories_btn
            // 
            this.RangeCalories_btn.Location = new System.Drawing.Point(376, 75);
            this.RangeCalories_btn.Name = "RangeCalories_btn";
            this.RangeCalories_btn.Size = new System.Drawing.Size(179, 50);
            this.RangeCalories_btn.TabIndex = 6;
            this.RangeCalories_btn.Text = "Vegetables and fruits with caloric content in the RANGE";
            this.RangeCalories_btn.UseVisualStyleBackColor = true;
            this.RangeCalories_btn.Click += new System.EventHandler(this.RangeCalories_btn_Click);
            // 
            // YellowRedColor_btn
            // 
            this.YellowRedColor_btn.Location = new System.Drawing.Point(555, 75);
            this.YellowRedColor_btn.Name = "YellowRedColor_btn";
            this.YellowRedColor_btn.Size = new System.Drawing.Size(179, 50);
            this.YellowRedColor_btn.TabIndex = 7;
            this.YellowRedColor_btn.Text = "All vegetables and fruits are yellow or red in color";
            this.YellowRedColor_btn.UseVisualStyleBackColor = true;
            this.YellowRedColor_btn.Click += new System.EventHandler(this.YellowRedColor_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 662);
            this.Controls.Add(this.disconnection_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Connection_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Connection_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button allInfo_btn;
        private System.Windows.Forms.Button allName_btn;
        private System.Windows.Forms.Button allColor_btn;
        private System.Windows.Forms.Button maxCalories_btn;
        private System.Windows.Forms.Button minCalories_btn;
        private System.Windows.Forms.Button avgCalories_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button colorsCount_btn;
        private System.Windows.Forms.Button colorCount_btn;
        private System.Windows.Forms.Button fruitsCount_btn;
        private System.Windows.Forms.Button vagetablesCount_btn;
        private System.Windows.Forms.Button disconnection_btn;
        private System.Windows.Forms.Button YellowRedColor_btn;
        private System.Windows.Forms.Button RangeCalories_btn;
        private System.Windows.Forms.Button HighCalories_btn;
        private System.Windows.Forms.Button LowCalories_btn;
    }
}

