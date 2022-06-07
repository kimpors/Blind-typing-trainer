using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blind_typing_trainer.MyControls
{
    public partial class MyShortTextInfoDialog : Form
    {
        public MyShortTextInfoDialog(Theme theme)
        {
            InitializeComponent();
            SetTheme(theme);
        }

        void SetTheme(Theme theme)
        {
            theme.SetTheme(this);
            Ok.BackColor = theme.backColor;
        }
    }
}
