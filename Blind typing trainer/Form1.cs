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
        private int symbolCount = 0, mistake = 0, mistakePlace = 0;
        private bool isLight = true;
        private TimeSpan timer = new TimeSpan(0, 0, 0);
        private FabricTheme currTheme = new FabricLight();

        public Form1()
        {
            InitializeComponent();

            TypingField.Text = "Text here!";
            Start.FlatAppearance.BorderSize = Theme.FlatAppearance.BorderSize = Reset.FlatAppearance.BorderSize = 0;
            SeTheme();
        }

        private void SeTheme()
        {
            var theme = currTheme.CreateTheme();

            menuStrip1.Renderer = new ToolStripProfessionalRenderer(theme.CreateColorStrip());

            menuStrip1.BackColor = theme.darkBackColor;
            menuStrip1.ForeColor = theme.foreColor;

            openToolStripMenuItem.ForeColor = theme.foreColor;
            freeToolStripMenuItem.ForeColor = theme.foreColor;
            raceToolStripMenuItem.ForeColor = theme.foreColor;
            languageToolStripMenuItem.ForeColor = theme.foreColor;
            themeToolStripMenuItem.ForeColor = theme.foreColor;

            BackColor = theme.darkBackColor;

            TypingField.BackColor = theme.backColor;
            TypingField.ForeColor = theme.foreColor;

            TypingField.SelectAll();
            TypingField.SelectionBackColor = theme.backColor;
            TypingField.SelectionColor = theme.foreColor;

            TypingField.Select(0, mistakePlace);
            TypingField.SelectionColor = Color.LimeGreen;

            TypingField.Select(mistakePlace, symbolCount - mistakePlace);
            TypingField.SelectionBackColor = Color.Red;


            Start.BackColor = theme.backColor;
            Start.ForeColor = theme.foreColor;

            Time.ForeColor = theme.foreColor;
            Speed.ForeColor = theme.foreColor;
            StartTimer.ForeColor = theme.foreColor;
            label1.ForeColor = theme.foreColor;
            label2.ForeColor = theme.foreColor;
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (StartTimer.Text == "0")
            {
                TypingField.SelectionLength = 1;
                TypingField.SelectionStart = symbolCount;

                if (e.KeyChar == '\b')
                {
                    if (symbolCount == 0) return;

                    mistake++;
                    TypingField.SelectionStart = symbolCount -= 1;

                    SeTheme();
                    return;
                }

                if (e.KeyChar == TypingField.Text[symbolCount] && mistakePlace == 0)
                {
                    TypingField.SelectionColor = Color.LimeGreen;
                }
                else
                {
                    mistake++;
                    mistakePlace = mistakePlace == 0 ? symbolCount : mistakePlace;
                    TypingField.SelectionBackColor = Color.Red;
                }


                symbolCount++;

                if (symbolCount == TypingField.Text.Length)
                {
                    timerTick.Enabled = false;
                    timer = new TimeSpan(0, 0, 0);
                    StartTimer.Text = "3";
                    Start.Text = "Start";
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
            if (StartTimer.Text == "0")
            {
                timer = timer.Add(new TimeSpan(0, 0, 1));
                Time.Text = timer.ToString();

                Speed.Text = ((int)((symbolCount + mistake) / (timer.TotalMinutes) / 5)).ToString() + "WP";
            }
            else
            {
                StartTimer.Text = (int.Parse(StartTimer.Text) - 1).ToString();
            }
        }
        private void Theme_Click(object sender, EventArgs e)
        {
            isLight = !isLight;

            if (isLight)
                currTheme = new FabricLight();
            else
                currTheme = new FabricDark();

            SeTheme();
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            if (Start.Text == "Start")
            {
                symbolCount = mistake = mistakePlace = 0;
                Speed.Text = "0WP";
                Time.Text = "00:00:00";
                SeTheme();
            }
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

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

                Reset.PerformClick();
            }
        }
    }
}
