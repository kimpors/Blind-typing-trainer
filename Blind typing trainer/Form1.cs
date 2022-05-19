using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;


namespace Blind_typing_trainer
{
    public partial class Form1 : Form
    {
        private int symbolCount, mistake, mistakePlace;
        private string allText;
        private bool isLight;
        private TimeSpan timer;
        private FabricTheme currTheme;
        private Rectangle origFormSize, origTypingFieldRec;
        private float origTypingFieldFontSize;
        private const int NOTHING = -1;

        public Form1()
        {
            InitializeComponent();
            freeToolStripMenuItem.Checked = true;
            StartTimer.Visible = false;
            isLight = true;
            currTheme = new FabricLight();
            SetTheme();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            allText = TypingField.Text = "Text here";
            symbolCount = mistake = 0;
            mistakePlace = NOTHING;

            timer = new TimeSpan(0, 0, 0);
            origFormSize = new Rectangle(Location, Size);
            origTypingFieldRec = new Rectangle(TypingField.Location, TypingField.Size);
            origTypingFieldFontSize = TypingField.Font.Size;
        }

        private void SetTheme()
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
            englishToolStripMenuItem.ForeColor = theme.foreColor;
            russiaToolStripMenuItem.ForeColor = theme.foreColor;
            ukraineToolStripMenuItem.ForeColor = theme.foreColor;


            BackColor = theme.darkBackColor;

            TypingField.BackColor = theme.backColor;
            TypingField.ForeColor = theme.foreColor;

            TypingField.SelectAll();
            TypingField.SelectionBackColor = theme.backColor;
            TypingField.SelectionColor = theme.foreColor;

            Start.BackColor = theme.backColor;
            Start.ForeColor = theme.foreColor;

            Time.ForeColor = theme.foreColor;
            Speed.ForeColor = theme.foreColor;

            StartTimer.BackColor = theme.backColor;
            StartTimer.ForeColor = theme.foreColor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeFont(origTypingFieldRec, TypingField, origTypingFieldFontSize);
        }

        private void PaintLetters()
        {
            if (symbolCount > 0)
            {
                TypingField.Select(0, mistakePlace != NOTHING ? mistakePlace : symbolCount);
                TypingField.SelectionColor = Color.LimeGreen;
            }


            if (mistakePlace != NOTHING)
            {
                TypingField.Select(mistakePlace, mistakePlace != NOTHING ? symbolCount - mistakePlace : symbolCount);
                TypingField.SelectionBackColor = Color.Red;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (StartTimer.Text == "GO!!!")
            {
                if (symbolCount == TypingField.Text.Length) symbolCount--;

                if (e.KeyChar == '\b')
                {
                    if (symbolCount > 0)
                    {
                        mistake++;
                        symbolCount--;

                        if (symbolCount == mistakePlace) mistakePlace = NOTHING;

                        SetTheme();
                        PaintLetters();
                    }
                    return;
                }
                else if (e.KeyChar != TypingField.Text[symbolCount])
                {
                    mistakePlace = mistakePlace == NOTHING ? symbolCount : mistakePlace;
                    mistake++;
                }

                symbolCount++;
                PaintLetters();

                if (symbolCount == TypingField.Text.Length && mistakePlace == NOTHING)
                {
                    timerTick.Enabled = false;
                    timer = new TimeSpan(0, 0, 0);
                    StartTimer.Text = "3";
                    Start.Text = "Start";
                    return;
                }
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            timerTick.Enabled = !timerTick.Enabled;

            StartTimer.Text = "3";
            StartTimer.Visible = Start.Text == "Start" ? true : false;
            Start.Text = timerTick.Enabled && symbolCount != TypingField.Text.Length ? "Stop" : "Start";

            if (allText.Length > 1000 && Start.Text == "Stop")
            {
                TypingField.Text = Regex.Match(allText.Substring(new Random()
                    .Next(1, allText.Length - 1000)).Replace("  ", ""), @"[A-ZА-Я]+.{300,1000}\.").Value;
            }

            /*if (raceToolStripMenuItem.Checked && Start.Text == "Stop")
            {
                TypingField.Text = Regex.Match(allText.Substring(new Random().Next(1, allText.Length - 1000))
                    .Replace("  ", ""), @"[A-ZА-Я]+.{300,1000}\.").Value;
            }*/
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (StartTimer.Text == "GO!!!")
            {
                StartTimer.Visible = false;

                timer = timer.Add(new TimeSpan(0, 0, 1));
                Time.Text = "Time: " + timer.ToString();

                Speed.Text = "Speed: " + ((int)((symbolCount + mistake) / timer.TotalMinutes / 5)).ToString() + "WP";
            }
            else
            {
                StartTimer.Text = StartTimer.Text != "1" ? (int.Parse(StartTimer.Text) - 1).ToString() : "GO!!!";
            }
        }
        private void Theme_Click(object sender, EventArgs e)
        {
            isLight = !isLight;

            if (isLight)
                currTheme = new FabricLight();
            else
                currTheme = new FabricDark();

            SetTheme();
            PaintLetters();
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            if (Start.Text == "Start")
            {
                symbolCount = mistake = mistakePlace = 0;
                Speed.Text = "Speed: 0WP";
                Time.Text = "Time: 00:00:00";
                SetTheme();
            }
        }
        private void raceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allText.Length < 1000)
            {
                new ToolTip().Show("Small text. Need 1000 or more letters", menuStrip1, 50, 30, 1200);
                raceToolStripMenuItem.Checked = false;
            }
            else
            {
                raceToolStripMenuItem.Checked = true;
                freeToolStripMenuItem.Checked = false;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
                Start_Click(Start, null);
            else if (e.KeyData == Keys.Q && Start.Text == "Start")
                button1_Click(nsButton1, null);
        }
        private void resizeFont(Rectangle r, Control c, float origFontSize)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                float xRatio = (float)this.ClientRectangle.Width / (float)origFormSize.Width;
                float yRatio = (float)this.ClientRectangle.Height / (float)origFormSize.Height;

                float newFontSize = xRatio >= yRatio ? origFontSize * yRatio : origFontSize * xRatio;
                c.Font = new Font(c.Font.FontFamily, newFontSize);
            }
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
                    allText = File.ReadAllText(openFileDialog1.FileName);
                }
                else if (Path.GetExtension(openFileDialog1.FileName) == ".rtf")
                {
                    using (var rtf = new RichTextBox())
                    {
                        rtf.LoadFile(openFileDialog1.FileName);
                        allText = rtf.Text;
                    }
                }
                Reset.PerformClick();
            }
        }
    }
}
