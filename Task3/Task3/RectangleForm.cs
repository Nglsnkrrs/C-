using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public class RectangleForm : Form1
    {
        private Rectangle innerRect;

        public RectangleForm()
        {
            this.Text = "Обработка мыши";
            this.ClientSize = new Size(400, 300);
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.Resize += Form_Resize;

            UpdateInnerRect();
        }

        private void UpdateInnerRect()
        {
            innerRect = new Rectangle(10, 10, ClientSize.Width - 20, ClientSize.Height - 20);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(Pens.Black, innerRect);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            UpdateInnerRect();
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    Application.Exit();
                    return;
                }

                string location;

                if (innerRect.Contains(e.Location))
                {

                    int margin = 1;
                    bool onLeft = Math.Abs(e.X - innerRect.Left) <= margin;
                    bool onRight = Math.Abs(e.X - innerRect.Right) <= margin;
                    bool onTop = Math.Abs(e.Y - innerRect.Top) <= margin;
                    bool onBottom = Math.Abs(e.Y - innerRect.Bottom) <= margin;

                    if (onLeft || onRight || onTop || onBottom)
                    {
                        location = "На границе прямоугольника";
                    }
                    else
                    {
                        location = "Внутри прямоугольника";
                    }
                }
                else
                {
                    location = "Снаружи прямоугольника";
                }

                MessageBox.Show(location, "Координаты: " + e.Location.ToString());
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.Text = $"Ширина = {ClientSize.Width}, Высота = {ClientSize.Height}";
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"x = {e.X}, y = {e.Y}";
        }
    }
}
