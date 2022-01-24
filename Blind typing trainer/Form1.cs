using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Blind_typing_trainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TypingField.Text = "Привет как дела, Slimy sculpin sand tiger wolf-eel marlin tubeblenny, oceanic flyingfish, cookie-cutter shark porbeagle shark:Peter's";
        }

        private static int index = 0;
        private static TimeSpan timer = new TimeSpan(0, 0, 0);
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = e.KeyChar.ToString();

            if (e.KeyChar == '\b')
            {
                if (index == 0) return;

                TypingField.SelectionStart = index - 1;
                TypingField.SelectionLength = index;
                TypingField.SelectionBackColor = Color.GhostWhite;
                index--;
                return;
            }

            if (index == TypingField.Text.Length)
            {
                timerTick.Enabled = false;
                timer = new TimeSpan(0,0,0);
                return;
            }

            index++;
            TypingField.SelectionStart = index - 1;
            TypingField.SelectionLength = 1;


            if (e.KeyChar == TypingField.Text[index - 1])
                TypingField.SelectionBackColor = Color.GreenYellow;
            else
                TypingField.SelectionBackColor = Color.Red;


            e.Handled = true;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            timerTick.Enabled = !timerTick.Enabled;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (index != TypingField.Text.Length)
            {
                timer = timer.Add(new TimeSpan(0, 0, 1));
                Time.Text = timer.ToString();
            }
        }
    }
}
