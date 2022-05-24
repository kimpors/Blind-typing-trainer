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
using System.Globalization;
using System.Configuration;
using NLipsum.Core;
using System.Runtime.Serialization.Formatters.Binary;


namespace Blind_typing_trainer
{
    public partial class Form1 : Form
    {
        private int symbolCount, mistake, mistakePlace;
        private double raceResult;
        private string allText;
        private TimeSpan timer;
        private User user;
        private Theme currTheme;
        private ILanguage currLanguage;
        private Rectangle origFormSize;
        private float origTypingFieldFontSize;
        private const int NOTHING = -1;

        public Form1()
        {
            InitializeComponent();


            using (Stream file = File.Open("User.dat", FileMode.OpenOrCreate))
            {
                if (file.Length > 0)
                {
                    user = (User)new BinaryFormatter().Deserialize(file);
                }
            }

            if (user == null)
            {
                user = new User(new SwtichTheme().SwitchLight(),
                    new SwitchLanguage().SwitchEng(),
                    new TimeSpan(0, 0, 0), new List<float>() { 0 });
            }
            currLanguage = user.currLanguage;
            allText = TypingField.Text = currLanguage.Standart;
            currTheme = user.currTheme;
            SetTheme();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string currentLanguage = ConfigurationManager.AppSettings["language"];

            if (currentLanguage == "en-US")
                currLanguage = new SwitchLanguage().SwitchEng();
            else if (currentLanguage == "uk-UA")
                currLanguage = new SwitchLanguage().SwitchUkr();
            else
                currLanguage = new SwitchLanguage().SwitchRus();

            aveSpeed.Text = currLanguage.AverageSpeed + user.allRuns.Average();
            allTime.Text = currLanguage.AllTimeOfTraining + user.trainingTime.ToString();

            symbolCount = mistake = 0;
            mistakePlace = NOTHING;


            timer = new TimeSpan(0, 0, 0);
            origFormSize = new Rectangle(Location, Size);
            origTypingFieldFontSize = TypingField.Font.Size;
        }

        private void SetTheme()
        {
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(currTheme.CreateColorStrip());

            menuStrip1.BackColor = currTheme.darkBackColor;
            menuStrip1.ForeColor = currTheme.foreColor;

            foreach (ToolStripMenuItem st in menuStrip1.Items)
            {
                st.ForeColor = currTheme.foreColor;
                foreach (var dt in st.DropDownItems)
                {
                    ((ToolStripMenuItem)dt).ForeColor = currTheme.foreColor;
                }
            }


            BackColor = currTheme.darkBackColor;

            TypingField.BackColor = currTheme.backColor;
            TypingField.ForeColor = currTheme.foreColor;

            TypingField.SelectAll();
            TypingField.SelectionBackColor = currTheme.backColor;
            TypingField.SelectionColor = currTheme.foreColor;

            Start.BackColor = currTheme.backColor;
            Start.ForeColor = currTheme.foreColor;

            Time.ForeColor = currTheme.foreColor;
            Speed.ForeColor = currTheme.foreColor;
            aveSpeed.ForeColor = currTheme.foreColor;
            allTime.ForeColor = currTheme.foreColor;


            StartTimer.BackColor = currTheme.backColor;
            StartTimer.ForeColor = currTheme.foreColor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

            aveSpeed.Text = currLanguage.AverageSpeed + user.allRuns.Average().ToString(".00");
            allTime.Text = currLanguage.AllTimeOfTraining + user.trainingTime;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                float xRatio = (float)this.ClientRectangle.Width / (float)origFormSize.Width;
                float yRatio = (float)this.ClientRectangle.Height / (float)origFormSize.Height;

                float newFontSize = xRatio >= yRatio ? origTypingFieldFontSize * yRatio : origTypingFieldFontSize * xRatio;
                TypingField.Font = new Font(TypingField.Font.FontFamily, newFontSize);
            }
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
                    StartTimer.Text = "3";
                    Start.Text = currLanguage.Start;
                    user.trainingTime = user.trainingTime.Add(timer);
                    user.AddRun((float)raceResult);
                    timer = new TimeSpan(0, 0, 0);
                    return;
                }
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            Reset_Click(Reset, null);
            panel1.Visible = false;
            timerTick.Enabled = !timerTick.Enabled;

            StartTimer.Text = "3";
            StartTimer.Visible = Start.Text == currLanguage.Start ? true : false;
            Start.Text = timerTick.Enabled && symbolCount != TypingField.Text.Length ? currLanguage.Stop : currLanguage.Start;

            if (Start.Text == currLanguage.Stop && allText != currLanguage.Standart)
            {
                TypingField.Text = Regex.Match(allText.Substring(new Random()
                    .Next(1, allText.Length - 1000)).Replace("  ", ""), @"[A-Za-z]+.{100,1000}\.").Value;
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (StartTimer.Text == "GO!!!")
            {
                StartTimer.Visible = false;

                timer = timer.Add(new TimeSpan(0, 0, 1));
                Time.Text = $"{currLanguage.Time} " + timer.ToString();

                raceResult = (symbolCount + mistake) / timer.TotalMinutes / 5;
                Speed.Text = $"{currLanguage.Speed} " + ((int)raceResult).ToString() + "WP";
            }
            else
            {
                StartTimer.Text = StartTimer.Text != "1" ? (int.Parse(StartTimer.Text) - 1).ToString() : "GO!!!";
            }
        }
        private void Theme_Click(object sender, EventArgs e)
        {
            if (currTheme.GetType() == new SwtichTheme().SwitchDark().GetType()) 
                currTheme = new SwtichTheme().SwitchLight();
            else
                currTheme = new SwtichTheme().SwitchDark();

            SetTheme();
            PaintLetters();
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            if (Start.Text == currLanguage.Start)
            {
                symbolCount = mistake = 0;
                mistakePlace = NOTHING;
                Speed.Text = $"{currLanguage.Speed} 0WP";
                Time.Text = $"{currLanguage.Time} 00:00:00";
                SetTheme();
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
                Start_Click(Start, null);
            else if (e.KeyData == Keys.Q && Start.Text == "Start")
                button1_Click(nsButton1, null);
        }
        private void ChangeLanguage(string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;

            var entry = settings["language"];
            entry.Value = value;

            config.Save(ConfigurationSaveMode.Modified);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(currLanguage.InfoHotKeys, currLanguage.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en-US");
            currLanguage = new SwitchLanguage().SwitchEng();
            Application.Restart();
        }
        private void ukraineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("uk-UA");
            currLanguage = new SwitchLanguage().SwitchUkr();
            Application.Restart();
        }
        private void russiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("ru-RU");
            currLanguage = new SwitchLanguage().SwitchRus();
            Application.Restart();
        }
        private void loremIpsumGenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypingField.Text = string.Join("", new LipsumGenerator().GenerateSentences(new Random().Next(5, 13)));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            user.currLanguage = currLanguage;
            user.currTheme = currTheme;

            using (Stream file = File.Open("User.dat", FileMode.Open))
            {
                new BinaryFormatter().Serialize(file, user);
            }
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

                if (allText.Length < 1000)
                {
                    MessageBox.Show(currLanguage.ShortTextInfo, currLanguage.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    allText = currLanguage.Standart;
                }

                Reset_Click(Reset, null);
            }
        }
    }
}
