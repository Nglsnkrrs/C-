namespace BestOil
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label_allSum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Oil = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_count = new System.Windows.Forms.TextBox();
            this.textBox_sum = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton_sum = new System.Windows.Forms.RadioButton();
            this.radioButton_count = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_allCafeSum = new System.Windows.Forms.Button();
            this.groupBox_allSumCafe = new System.Windows.Forms.GroupBox();
            this.label_allSumcafe = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_HotDogCount = new System.Windows.Forms.TextBox();
            this.textBox_burgerCount = new System.Windows.Forms.TextBox();
            this.textBox_FreeCount = new System.Windows.Forms.TextBox();
            this.textBox_ColaCount = new System.Windows.Forms.TextBox();
            this.textBox_burgerPrice = new System.Windows.Forms.TextBox();
            this.textBox_FrrePrice = new System.Windows.Forms.TextBox();
            this.textBox_ColaPrice = new System.Windows.Forms.TextBox();
            this.textBox_HotDogPrice = new System.Windows.Forms.TextBox();
            this.checkBox_Cola = new System.Windows.Forms.CheckBox();
            this.checkBox_Free = new System.Windows.Forms.CheckBox();
            this.checkBox_Burger = new System.Windows.Forms.CheckBox();
            this.checkBox_HotDog = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_Sum = new System.Windows.Forms.Label();
            this.button_AllSumBestOil = new System.Windows.Forms.Button();
            this.button_pay = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_allSumCafe.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.comboBox_Oil);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_count);
            this.groupBox1.Controls.Add(this.textBox_sum);
            this.groupBox1.Controls.Add(this.textBox_Price);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 713);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Автозаправка";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(357, 62);
            this.button1.TabIndex = 10;
            this.button1.Text = "Рассчитать стоимость";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label_allSum);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(22, 512);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(406, 182);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "На оплату";
            // 
            // label_allSum
            // 
            this.label_allSum.AutoSize = true;
            this.label_allSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label_allSum.Location = new System.Drawing.Point(151, 76);
            this.label_allSum.Name = "label_allSum";
            this.label_allSum.Size = new System.Drawing.Size(36, 39);
            this.label_allSum.TabIndex = 11;
            this.label_allSum.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.Location = new System.Drawing.Point(323, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 31);
            this.label5.TabIndex = 10;
            this.label5.Text = "руб";
            // 
            // comboBox_Oil
            // 
            this.comboBox_Oil.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.comboBox_Oil.FormattingEnabled = true;
            this.comboBox_Oil.Location = new System.Drawing.Point(208, 102);
            this.comboBox_Oil.Name = "comboBox_Oil";
            this.comboBox_Oil.Size = new System.Drawing.Size(169, 39);
            this.comboBox_Oil.TabIndex = 8;
            this.comboBox_Oil.SelectedIndexChanged += new System.EventHandler(this.comboBox_Oil_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(389, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "руб";
            // 
            // textBox_count
            // 
            this.textBox_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox_count.Location = new System.Drawing.Point(255, 325);
            this.textBox_count.Name = "textBox_count";
            this.textBox_count.ReadOnly = true;
            this.textBox_count.Size = new System.Drawing.Size(122, 38);
            this.textBox_count.TabIndex = 6;
            // 
            // textBox_sum
            // 
            this.textBox_sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox_sum.Location = new System.Drawing.Point(255, 376);
            this.textBox_sum.Name = "textBox_sum";
            this.textBox_sum.ReadOnly = true;
            this.textBox_sum.Size = new System.Drawing.Size(122, 38);
            this.textBox_sum.TabIndex = 5;
            // 
            // textBox_Price
            // 
            this.textBox_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox_Price.Location = new System.Drawing.Point(208, 169);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.ReadOnly = true;
            this.textBox_Price.Size = new System.Drawing.Size(169, 38);
            this.textBox_Price.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton_sum);
            this.groupBox4.Controls.Add(this.radioButton_count);
            this.groupBox4.Location = new System.Drawing.Point(6, 302);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 125);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // radioButton_sum
            // 
            this.radioButton_sum.AutoSize = true;
            this.radioButton_sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.radioButton_sum.Location = new System.Drawing.Point(16, 77);
            this.radioButton_sum.Name = "radioButton_sum";
            this.radioButton_sum.Size = new System.Drawing.Size(119, 35);
            this.radioButton_sum.TabIndex = 1;
            this.radioButton_sum.Text = "Сумма";
            this.radioButton_sum.UseVisualStyleBackColor = true;
            this.radioButton_sum.CheckedChanged += new System.EventHandler(this.radioButtonChecked);
            // 
            // radioButton_count
            // 
            this.radioButton_count.AutoSize = true;
            this.radioButton_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.radioButton_count.Location = new System.Drawing.Point(16, 26);
            this.radioButton_count.Name = "radioButton_count";
            this.radioButton_count.Size = new System.Drawing.Size(179, 35);
            this.radioButton_count.TabIndex = 0;
            this.radioButton_count.Text = "Количество";
            this.radioButton_count.UseVisualStyleBackColor = true;
            this.radioButton_count.CheckedChanged += new System.EventHandler(this.radioButtonChecked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(389, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "руб";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(28, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Цена";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(28, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Бензин";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_allCafeSum);
            this.groupBox2.Controls.Add(this.groupBox_allSumCafe);
            this.groupBox2.Controls.Add(this.textBox_HotDogCount);
            this.groupBox2.Controls.Add(this.textBox_burgerCount);
            this.groupBox2.Controls.Add(this.textBox_FreeCount);
            this.groupBox2.Controls.Add(this.textBox_ColaCount);
            this.groupBox2.Controls.Add(this.textBox_burgerPrice);
            this.groupBox2.Controls.Add(this.textBox_FrrePrice);
            this.groupBox2.Controls.Add(this.textBox_ColaPrice);
            this.groupBox2.Controls.Add(this.textBox_HotDogPrice);
            this.groupBox2.Controls.Add(this.checkBox_Cola);
            this.groupBox2.Controls.Add(this.checkBox_Free);
            this.groupBox2.Controls.Add(this.checkBox_Burger);
            this.groupBox2.Controls.Add(this.checkBox_HotDog);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groupBox2.Location = new System.Drawing.Point(497, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 713);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Кафе";
            // 
            // button_allCafeSum
            // 
            this.button_allCafeSum.Location = new System.Drawing.Point(141, 394);
            this.button_allCafeSum.Name = "button_allCafeSum";
            this.button_allCafeSum.Size = new System.Drawing.Size(357, 62);
            this.button_allCafeSum.TabIndex = 11;
            this.button_allCafeSum.Text = "Рассчитать стоимость";
            this.button_allCafeSum.UseVisualStyleBackColor = true;
            this.button_allCafeSum.Click += new System.EventHandler(this.button_allCafeSum_Click);
            // 
            // groupBox_allSumCafe
            // 
            this.groupBox_allSumCafe.Controls.Add(this.label_allSumcafe);
            this.groupBox_allSumCafe.Controls.Add(this.label7);
            this.groupBox_allSumCafe.Location = new System.Drawing.Point(48, 512);
            this.groupBox_allSumCafe.Name = "groupBox_allSumCafe";
            this.groupBox_allSumCafe.Size = new System.Drawing.Size(558, 182);
            this.groupBox_allSumCafe.TabIndex = 12;
            this.groupBox_allSumCafe.TabStop = false;
            this.groupBox_allSumCafe.Text = "На оплату";
            // 
            // label_allSumcafe
            // 
            this.label_allSumcafe.AutoSize = true;
            this.label_allSumcafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label_allSumcafe.Location = new System.Drawing.Point(177, 76);
            this.label_allSumcafe.Name = "label_allSumcafe";
            this.label_allSumcafe.Size = new System.Drawing.Size(36, 39);
            this.label_allSumcafe.TabIndex = 11;
            this.label_allSumcafe.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label7.Location = new System.Drawing.Point(458, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 31);
            this.label7.TabIndex = 10;
            this.label7.Text = "руб";
            // 
            // textBox_HotDogCount
            // 
            this.textBox_HotDogCount.Location = new System.Drawing.Point(447, 64);
            this.textBox_HotDogCount.Name = "textBox_HotDogCount";
            this.textBox_HotDogCount.ReadOnly = true;
            this.textBox_HotDogCount.Size = new System.Drawing.Size(141, 38);
            this.textBox_HotDogCount.TabIndex = 11;
            // 
            // textBox_burgerCount
            // 
            this.textBox_burgerCount.Location = new System.Drawing.Point(447, 145);
            this.textBox_burgerCount.Name = "textBox_burgerCount";
            this.textBox_burgerCount.ReadOnly = true;
            this.textBox_burgerCount.Size = new System.Drawing.Size(141, 38);
            this.textBox_burgerCount.TabIndex = 10;
            // 
            // textBox_FreeCount
            // 
            this.textBox_FreeCount.Location = new System.Drawing.Point(447, 226);
            this.textBox_FreeCount.Name = "textBox_FreeCount";
            this.textBox_FreeCount.ReadOnly = true;
            this.textBox_FreeCount.Size = new System.Drawing.Size(141, 38);
            this.textBox_FreeCount.TabIndex = 9;
            // 
            // textBox_ColaCount
            // 
            this.textBox_ColaCount.Location = new System.Drawing.Point(447, 302);
            this.textBox_ColaCount.Name = "textBox_ColaCount";
            this.textBox_ColaCount.ReadOnly = true;
            this.textBox_ColaCount.Size = new System.Drawing.Size(141, 38);
            this.textBox_ColaCount.TabIndex = 8;
            // 
            // textBox_burgerPrice
            // 
            this.textBox_burgerPrice.Location = new System.Drawing.Point(232, 144);
            this.textBox_burgerPrice.Name = "textBox_burgerPrice";
            this.textBox_burgerPrice.ReadOnly = true;
            this.textBox_burgerPrice.Size = new System.Drawing.Size(141, 38);
            this.textBox_burgerPrice.TabIndex = 7;
            // 
            // textBox_FrrePrice
            // 
            this.textBox_FrrePrice.Location = new System.Drawing.Point(232, 226);
            this.textBox_FrrePrice.Name = "textBox_FrrePrice";
            this.textBox_FrrePrice.ReadOnly = true;
            this.textBox_FrrePrice.Size = new System.Drawing.Size(141, 38);
            this.textBox_FrrePrice.TabIndex = 6;
            // 
            // textBox_ColaPrice
            // 
            this.textBox_ColaPrice.Location = new System.Drawing.Point(232, 299);
            this.textBox_ColaPrice.Name = "textBox_ColaPrice";
            this.textBox_ColaPrice.ReadOnly = true;
            this.textBox_ColaPrice.Size = new System.Drawing.Size(141, 38);
            this.textBox_ColaPrice.TabIndex = 5;
            // 
            // textBox_HotDogPrice
            // 
            this.textBox_HotDogPrice.Location = new System.Drawing.Point(232, 64);
            this.textBox_HotDogPrice.Name = "textBox_HotDogPrice";
            this.textBox_HotDogPrice.ReadOnly = true;
            this.textBox_HotDogPrice.Size = new System.Drawing.Size(141, 38);
            this.textBox_HotDogPrice.TabIndex = 4;
            // 
            // checkBox_Cola
            // 
            this.checkBox_Cola.AutoSize = true;
            this.checkBox_Cola.Location = new System.Drawing.Point(30, 302);
            this.checkBox_Cola.Name = "checkBox_Cola";
            this.checkBox_Cola.Size = new System.Drawing.Size(96, 35);
            this.checkBox_Cola.TabIndex = 3;
            this.checkBox_Cola.Text = "Кола";
            this.checkBox_Cola.UseVisualStyleBackColor = true;
            this.checkBox_Cola.CheckedChanged += new System.EventHandler(this.checkBox_Cola_CheckedChanged);
            // 
            // checkBox_Free
            // 
            this.checkBox_Free.AutoSize = true;
            this.checkBox_Free.Location = new System.Drawing.Point(30, 229);
            this.checkBox_Free.Name = "checkBox_Free";
            this.checkBox_Free.Size = new System.Drawing.Size(86, 35);
            this.checkBox_Free.TabIndex = 2;
            this.checkBox_Free.Text = "Фри";
            this.checkBox_Free.UseVisualStyleBackColor = true;
            this.checkBox_Free.CheckedChanged += new System.EventHandler(this.checkBox_Free_CheckedChanged);
            // 
            // checkBox_Burger
            // 
            this.checkBox_Burger.AutoSize = true;
            this.checkBox_Burger.Location = new System.Drawing.Point(30, 147);
            this.checkBox_Burger.Name = "checkBox_Burger";
            this.checkBox_Burger.Size = new System.Drawing.Size(166, 35);
            this.checkBox_Burger.TabIndex = 1;
            this.checkBox_Burger.Text = "Гамбургер";
            this.checkBox_Burger.UseVisualStyleBackColor = true;
            this.checkBox_Burger.CheckedChanged += new System.EventHandler(this.checkBox_Burger_CheckedChanged);
            // 
            // checkBox_HotDog
            // 
            this.checkBox_HotDog.AutoSize = true;
            this.checkBox_HotDog.Location = new System.Drawing.Point(30, 67);
            this.checkBox_HotDog.Name = "checkBox_HotDog";
            this.checkBox_HotDog.Size = new System.Drawing.Size(128, 35);
            this.checkBox_HotDog.TabIndex = 0;
            this.checkBox_HotDog.Text = "Хот-дог";
            this.checkBox_HotDog.UseVisualStyleBackColor = true;
            this.checkBox_HotDog.CheckedChanged += new System.EventHandler(this.checkBox_HotDog_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_pay);
            this.groupBox3.Controls.Add(this.button_AllSumBestOil);
            this.groupBox3.Controls.Add(this.label_Sum);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groupBox3.Location = new System.Drawing.Point(11, 788);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1112, 231);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Итоговая сумма";
            // 
            // label_Sum
            // 
            this.label_Sum.AutoSize = true;
            this.label_Sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label_Sum.Location = new System.Drawing.Point(494, 97);
            this.label_Sum.Name = "label_Sum";
            this.label_Sum.Size = new System.Drawing.Size(42, 46);
            this.label_Sum.TabIndex = 0;
            this.label_Sum.Text = "0";
            // 
            // button_AllSumBestOil
            // 
            this.button_AllSumBestOil.Location = new System.Drawing.Point(842, 125);
            this.button_AllSumBestOil.Name = "button_AllSumBestOil";
            this.button_AllSumBestOil.Size = new System.Drawing.Size(264, 100);
            this.button_AllSumBestOil.TabIndex = 1;
            this.button_AllSumBestOil.Text = "Рассчитать общую стоимость";
            this.button_AllSumBestOil.UseVisualStyleBackColor = true;
            this.button_AllSumBestOil.Click += new System.EventHandler(this.button_AllSumBestOil_Click);
            // 
            // button_pay
            // 
            this.button_pay.Location = new System.Drawing.Point(22, 139);
            this.button_pay.Name = "button_pay";
            this.button_pay.Size = new System.Drawing.Size(264, 72);
            this.button_pay.TabIndex = 2;
            this.button_pay.Text = "Оплатить";
            this.button_pay.UseVisualStyleBackColor = true;
            this.button_pay.Click += new System.EventHandler(this.button_pay_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button2.Location = new System.Drawing.Point(842, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(281, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "Завершить смену";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 1031);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Авто-касса";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_allSumCafe.ResumeLayout(false);
            this.groupBox_allSumCafe.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton_sum;
        private System.Windows.Forms.RadioButton radioButton_count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_count;
        private System.Windows.Forms.TextBox textBox_sum;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBox_Oil;
        private System.Windows.Forms.Label label_allSum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_Cola;
        private System.Windows.Forms.CheckBox checkBox_Free;
        private System.Windows.Forms.CheckBox checkBox_Burger;
        private System.Windows.Forms.CheckBox checkBox_HotDog;
        private System.Windows.Forms.TextBox textBox_HotDogCount;
        private System.Windows.Forms.TextBox textBox_burgerCount;
        private System.Windows.Forms.TextBox textBox_FreeCount;
        private System.Windows.Forms.TextBox textBox_ColaCount;
        private System.Windows.Forms.TextBox textBox_burgerPrice;
        private System.Windows.Forms.TextBox textBox_FrrePrice;
        private System.Windows.Forms.TextBox textBox_ColaPrice;
        private System.Windows.Forms.TextBox textBox_HotDogPrice;
        private System.Windows.Forms.Button button_allCafeSum;
        private System.Windows.Forms.GroupBox groupBox_allSumCafe;
        private System.Windows.Forms.Label label_allSumcafe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_AllSumBestOil;
        private System.Windows.Forms.Label label_Sum;
        private System.Windows.Forms.Button button_pay;
        private System.Windows.Forms.Button button2;
    }
}

