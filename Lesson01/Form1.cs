using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson01
{
    public partial class Form1 : Form
    {
        private bool CtrlPressed;

        public Form1()
        {
            InitializeComponent();
        }
        private String CoordinatesToString(MouseEventArgs e)
        {
            return "Mouse coordinates: х=" + e.X.ToString() +
            "; y=" + e.Y.ToString();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = CoordinatesToString(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CtrlPressed) this.Close();
            else
            {
                if(e.Button == MouseButtons.Left)
                {
                    Text = CoordinatesToString(e);
                    if ((e.X < 10 || e.Y < 10
                        || e.X > Width - 10 || e.Y > Height - 10))
                    {
                        Text += "; Outside rectangle";
                    }
                    else if ((e.X > 10 && e.Y > 10
                       && e.X < Width - 10 && e.Y < Height - 10))
                    {
                        Text += "; Inside rectangle";
                    }
                    else Text += "; On rectangle";
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control) this.CtrlPressed = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            this.CtrlPressed = false;
        }
    }
}
