using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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

        private int symbolCount = 0, mistake;
        private TimeSpan timer = new TimeSpan(0, 0, 0);
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Focus();

            if (e.KeyChar == '\b')
            {
      
                if (symbolCount == 0) return;
                mistake++;

                TypingField.SelectionStart = symbolCount - 1;
                TypingField.SelectionLength = symbolCount;
                TypingField.SelectionBackColor = Color.GhostWhite;
                symbolCount--;
                return;
            }

            if (symbolCount == TypingField.Text.Length)
            {
                timerTick.Enabled = false;
                timer = new TimeSpan(0,0,0);
                return;
            }

            symbolCount++;
            TypingField.SelectionStart = symbolCount - 1;
            TypingField.SelectionLength = 1;


            if (e.KeyChar == TypingField.Text[symbolCount - 1])
                TypingField.SelectionBackColor = Color.GreenYellow;
            else
            {
                mistake++;
                TypingField.SelectionBackColor = Color.Red;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            timerTick.Enabled = !timerTick.Enabled;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (symbolCount != TypingField.Text.Length)
            {
                timer = timer.Add(new TimeSpan(0, 0, 1));
                Time.Text = timer.ToString();

                Speed.Text = ((symbolCount + mistake) / (timer.TotalSeconds / 60) / 5).ToString(".00");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog1.FileName) == ".txt")
                {
                    TypingField.Text = File.ReadAllText(openFileDialog1.FileName);
                }
                else
                {
                    TypingField.LoadFile(openFileDialog1.FileName);
                }
            }
        }
    }
}
