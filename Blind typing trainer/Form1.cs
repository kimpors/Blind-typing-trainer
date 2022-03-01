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
using System.Runtime.InteropServices;



namespace Blind_typing_trainer
{
    public partial class Form1 : Form
    {
        private int symbolCount = 0, mistake = 0;
        private bool isLight = true;
        private TimeSpan timer = new TimeSpan(0, 0, 0);
        public Form1()
        {
            InitializeComponent();
            TypingField.Text = "Text here!";
            Start.FlatAppearance.BorderSize = 0;
            Theme.FlatAppearance.BorderSize = 0;
            Reset.FlatAppearance.BorderSize = 0;
            LightTheme();
        }

        private void currTheme()
        {
            if (isLight) LightTheme();
            else DarkTheme();
        }
        private void LightTheme()
        {
            menuStrip1.BackColor = Color.FromArgb(159, 167, 255);
            menuStrip1.ForeColor = Color.FromArgb(193, 196, 226);

            Start.BackColor = Color.FromArgb(202, 207, 255);
            Start.ForeColor = Color.FromArgb(66, 72, 128);

            TypingField.BackColor = Color.FromArgb(202, 207, 255);
            Restart();

            Time.ForeColor = Color.FromArgb(66, 72, 128);
            Speed.ForeColor = Color.FromArgb(66, 72, 128);
            StartTimer.ForeColor = Color.FromArgb(66, 72, 128);
            label1.ForeColor = Color.FromArgb(66, 72, 128);
            label2.ForeColor = Color.FromArgb(66, 72, 128);



            BackColor = Color.FromArgb(159, 167, 255);
            ForeColor = Color.FromArgb(66, 72, 128);
        }
        private void DarkTheme()
        {
            menuStrip1.BackColor = Color.FromArgb(45, 48, 78);
            menuStrip1.ForeColor = Color.FromArgb(193, 196, 226);


            Start.BackColor = Color.FromArgb(77, 80, 112);
            Start.ForeColor = Color.FromArgb(193, 196, 226);

            Theme.BackColor = Color.FromArgb(45, 48, 78);

            TypingField.BackColor = Color.FromArgb(77, 80, 112);
            Restart();

            Time.ForeColor = Color.FromArgb(193, 196, 226);
            Speed.ForeColor = Color.FromArgb(193, 196, 226);
            StartTimer.ForeColor = Color.FromArgb(193, 196, 226);
            label1.ForeColor = Color.FromArgb(193, 196, 226);
            label2.ForeColor = Color.FromArgb(193, 196, 226);


            BackColor = Color.FromArgb(45, 48, 78);
            ForeColor = Color.FromArgb(193, 196, 226);
        }

        private void Restart()
        {
            TypingField.SelectAll();

            if (isLight)
                TypingField.SelectionColor = Color.FromArgb(66, 72, 128);
            else
                TypingField.SelectionColor = Color.FromArgb(193, 196, 226);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                {
                    TypingField.SelectionColor = Color.LimeGreen;
                }  
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
            Start.Text = timerTick.Enabled && symbolCount != TypingField.Text.Length ? "Stop" : "Start";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (symbolCount == TypingField.Text.Length) return;

            if (StartTimer.Text == "0")
            {
                timer = timer.Add(new TimeSpan(0, 0, 1));
                Time.Text = timer.ToString();

                Speed.Text = ((symbolCount + mistake) / (timer.TotalMinutes) / 5).ToString();
            }
            else
            {
                StartTimer.Text = (Convert.ToInt16(StartTimer.Text) - 1).ToString();
            }
        }
        private void Theme_Click(object sender, EventArgs e)
        {
            isLight = !isLight;
            currTheme();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            symbolCount = mistake = 0;
            Restart();
        }

        private void TypingField_SelectionChanged(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void TypingField_MouseMove(object sender, MouseEventArgs e)
        {
            if (!TypingField.ClientRectangle.Contains(e.Location))
                TypingField.Capture = false;

            else if (!TypingField.Capture)
                TypingField.Capture = true;
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

                symbolCount = mistake = 0;
            }
        }
    }
}
