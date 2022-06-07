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
            SetTheme(currTheme);
            result = "No Name";
        }

        void SetTheme(Theme theme)
        {
            theme.SetTheme(this);
            Ok.BackColor = theme.backColor;
            textBox1.BackColor = theme.backColor;
            textBox1.ForeColor = theme.foreColor;
        }

        void Yes_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                result = textBox1.Text;
        }
    }
}
