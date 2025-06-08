using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Escaping_Static
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += label1_MouseMove;
        }
        Random rnd = new Random();

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            int distanceX = Math.Abs(e.X - label1.Location.X);
            int distanceY = Math.Abs(e.Y - label1.Location.Y);

            int safeDistance = 25;

            if (distanceX < safeDistance && distanceY < safeDistance)
            {
                MoveLabel();
            }
        }
            private void MoveLabel()
        {
            int maxX = this.ClientSize.Width - label1.Width;
            int maxY = this.ClientSize.Height - label1.Height;

            int newX = rnd.Next(0, maxX);
            int newY = rnd.Next(0, maxY);

            label1.Location = new Point(newX, newY);
        }
    }
}

