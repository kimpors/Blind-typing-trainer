using System;
using System.Windows.Forms;

namespace Blind_typing_trainer
{
    public partial class SaveDialog : Form
    {
        public string result { get; set; }
        public SaveDialog(Theme currTheme)
        {
            InitializeComponent();
            currTheme.SetTheme(this);
            Yes.BackColor = No.BackColor = currTheme.backColor;
            textBox1.BackColor = currTheme.backColor;
            textBox1.ForeColor = currTheme.backColor;

            result = "No Name";
        }

        void Yes_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                result = textBox1.Text;
        }
        void No_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
