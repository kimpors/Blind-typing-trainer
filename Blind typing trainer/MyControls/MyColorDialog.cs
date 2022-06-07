using System;
using System.Drawing;
using System.Windows.Forms;

namespace Blind_typing_trainer.MyControls
{
    public partial class MyColorDialog : Form
    {
        public Color newColor { get; set; }
        byte r, g, b;
        bool isSelected;
        public MyColorDialog(Theme currTheme)
        {
            InitializeComponent();
            SetTheme(currTheme);
            newColor = Color.White;
            isSelected = false;
        }

        void SetTheme(Theme theme)
        {
            theme.SetTheme(this);
            label4.BackColor = theme.backColor;
            Save.BackColor = theme.backColor;
            Save.ForeColor = theme.foreColor;
        }

        void Save_Click(object sender, EventArgs e)
        {
            newColor = Color.FromArgb(r, g, b);
        }

        void pictureBox1_Click(object sender, EventArgs e)
        {
            isSelected = true;
        }
        void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            isSelected = false;
        }
        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isSelected)
            {
                Bitmap bt = (Bitmap)pictureBox1.Image;
                Color cl = bt.GetPixel(e.Location.X, e.Location.Y);

                label4.BackColor = cl;
                numericUpDown1.Value = Convert.ToInt16(cl.R);
                numericUpDown2.Value = Convert.ToInt16(cl.G);
                numericUpDown3.Value = Convert.ToInt16(cl.B);
            }
        }

        void numeric_ValueChanged(object sender, EventArgs e)
        {
            r = (byte)numericUpDown1.Value;
            g = (byte)numericUpDown2.Value;
            b = (byte)numericUpDown3.Value;

            Color cl = Color.FromArgb(r, g, b);
            label4.BackColor = cl;
        }
    }
}
