using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public class Work_Form : Form1
    {

        private Point startPoint;
        private bool isDragging = false;
        private int labelCounter = 1;
        private List<Label> labels = new List<Label>();

        public Work_Form()
        {
            this.Text = "Создание статика";
            this.DoubleBuffered = true;
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
            this.MouseClick += Form_MouseClick;
            this.MouseDoubleClick += Form_MouseDoubleClick;
            this.ClientSize = new Size(600, 400);
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                isDragging = true;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Refresh(); 
                using (Graphics g = CreateGraphics())
                {
                    Rectangle rect = GetRectangle(startPoint, e.Location);
                    g.DrawRectangle(Pens.Blue, rect);
                }
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDragging)
            {
                isDragging = false;
                Rectangle rect = GetRectangle(startPoint, e.Location);

                if (rect.Width < 10 || rect.Height < 10)
                {
                    MessageBox.Show("Минимальный размер — 10x10!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Label lbl = new Label
                {
                    Text = labelCounter.ToString(),
                    Location = rect.Location,
                    Size = rect.Size,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightYellow,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = labelCounter
                };

                labels.Add(lbl);
                labelCounter++;

                lbl.MouseClick += Label_MouseClick;
                lbl.MouseDoubleClick += Label_MouseDoubleClick;

                this.Controls.Add(lbl);
            }
        }

        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var underCursor = labels
                    .Where(lbl => lbl.Bounds.Contains(e.Location))
                    .OrderByDescending(lbl => (int)lbl.Tag)
                    .FirstOrDefault();

                if (underCursor != null)
                {
                    int area = underCursor.Width * underCursor.Height;
                    Point relative = underCursor.Location;
                    this.Text = $"Площадь: {area}, Координаты: x={relative.X}, y={relative.Y}";
                }
            }

        }

        private void Form_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var underCursor = labels
                    .Where(lbl => lbl.Bounds.Contains(e.Location))
                    .OrderBy(lbl => (int)lbl.Tag)
                    .FirstOrDefault();

                if (underCursor != null)
                {
                    this.Controls.Remove(underCursor);
                    labels.Remove(underCursor);
                }
            }
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            Form_MouseClick(sender, e);
        }

        private void Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form_MouseDoubleClick(sender, e);
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p2.X - p1.X),
                Math.Abs(p2.Y - p1.Y));
        }
    }
}
