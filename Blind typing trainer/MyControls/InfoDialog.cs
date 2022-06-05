using System;
using System.Windows.Forms;

namespace Blind_typing_trainer
{
    public partial class InfoDialog : Form
    {
        public InfoDialog(Theme currTheme)
        {
            InitializeComponent();

            currTheme.SetTheme(this);
            Ok.BackColor = currTheme.backColor;
            richLabel1.BackColor = currTheme.secondBackColor;
            richLabel1.SelectionBackColor = currTheme.secondBackColor;
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
