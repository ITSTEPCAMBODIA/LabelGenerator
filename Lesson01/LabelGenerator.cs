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
    public partial class LabelGenerator : Form
    {
        MouseEventArgs startPoint;
        public LabelGenerator()
        {
            InitializeComponent();
        }

        private void LabelGenerator_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e;
        }

        private void LabelGenerator_MouseUp(object sender, MouseEventArgs e)
        {
            Label label = new Label();
            label.Width = Math.Abs(e.X - startPoint.X);
            label.Height = Math.Abs( e.Y - startPoint.Y);
            label.Location = new Point(Math.Min(startPoint.X,e.X)
                , Math.Min(startPoint.Y,e.Y));
            label.BackColor = Color.Red;
            label.MouseDown += new MouseEventHandler(Label_MouseDown);
            this.Controls.Add(label);
        }
        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            Text = $"Location: (X={label.Location.X},Y=" +
                $"{label.Location.Y})";
        }
    }
}
