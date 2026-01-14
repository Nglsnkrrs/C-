using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllApp
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        const uint WM_COPYDATA = 0x004A;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newText = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(newText))
            {
                MessageBox.Show("Введите текст!");
                return;
            }

            IntPtr hTarget = FindWindow(null, "TargetApp");
            if (hTarget == IntPtr.Zero)
            {
                MessageBox.Show("Целевое окно не найдено!");
                return;
            }

            // Отправляем сообщение WM_COPYDATA
            COPYDATASTRUCT cds;
            cds.dwData = IntPtr.Zero;
            cds.lpData = newText;
            cds.cbData = newText.Length + 1;

            SendMessage(hTarget, WM_COPYDATA, this.Handle, ref cds);
            MessageBox.Show("Текст отправлен в TargetApp!");
        }
    }
}