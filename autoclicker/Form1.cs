using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace autoclicker
{
    public partial class AutoClicker : Form
    {
        public AutoClicker()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwdata, int dwextainfo);
        public enum mouseeventflags
        {
            LeftDown = 2,
            LeftUp = 4,
        }
        public void leftClick(Point p)
        {
            mouse_event((int)(mouseeventflags.LeftDown),p.X,p.Y,0,0);
            mouse_event((int)(mouseeventflags.LeftUp), p.X, p.Y, 0, 0);
        }
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        bool stop = true;
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            leftClick(new Point(MousePosition.X,MousePosition.Y));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.F6))
            {
                timer1.Interval = (int)numericUpDown1.Value;
                timer1.Start();
            }
            if (Keyboard.IsKeyDown(Key.F7))
            {
                timer1.Interval = (int)numericUpDown1.Value;
                timer1.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer2.Interval = 1;
            timer2.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
