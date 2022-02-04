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
        private int symbolCount = 0, mistake;
        private TimeSpan timer = new TimeSpan(0, 0, 0);
        public Form1()
        {
            InitializeComponent();
            TypingField.Text = "Text here!";
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Focus();
            if (StartTimer.Text == "0")
            {
                TypingField.SelectionLength = 1;


                if (e.KeyChar == '\b')
                {
                    if (symbolCount == 0) return;

                    TypingField.SelectionStart = symbolCount;
                    TypingField.SelectionBackColor = DefaultBackColor;
                    TypingField.SelectionColor = DefaultForeColor;

                    symbolCount--;
                    mistake++;
                    return;
                }

                TypingField.SelectionStart = symbolCount;

                if (e.KeyChar == TypingField.Text[symbolCount])
                    TypingField.SelectionColor = Color.LimeGreen;
                else
                {
                    mistake++;
                    TypingField.SelectionBackColor = Color.Red;
                }


                symbolCount++;
                if (symbolCount == TypingField.Text.Length)
                {
                    timerTick.Enabled = false;
                    timer = new TimeSpan(0, 0, 0);
                    StartTimer.Text = "3";
                    return;
                }


                if (symbolCount % (int)(TypingField.Width / TypingField.Font.Size) == 0) TypingField.ScrollToCaret();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            timerTick.Enabled = !timerTick.Enabled;
            StartTimer.Text = "3";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (symbolCount == TypingField.Text.Length) return;

            if (StartTimer.Text == "0")
            {
                timer = timer.Add(new TimeSpan(0, 0, 1));
                Time.Text = timer.ToString();

                Speed.Text = ((symbolCount + mistake) / (timer.TotalMinutes) / 5).ToString(".00");
            }
            else
            {
                StartTimer.Text = (Convert.ToInt16(StartTimer.Text) - 1).ToString();
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

                symbolCount = mistake = -1;
            }
        }
    }
}
