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

        private string usual;
        private string start, stop;
        private string speed, time;
        private string shortTextInfo;
        private string infoStrip;
        private string averageSpeed, allTimeTraining;




        public Form1()
        {
            InitializeComponent();
            isLight = true;
            currTheme = new FabricLight();
            SetTheme();

            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string currLanguage = ConfigurationManager.AppSettings["language"];
            if (currLanguage == "en-US")
            {
                usual = "Text here";
                start = "Start";
                stop = "Stop";
                speed = "Speed:";
                time = "Time:";
                shortTextInfo = "Super short text (al least 1000 letters)";
                infoStrip = "F5 - start\nQ - Open panel";
                allTimeTraining = "All time of training:";
                averageSpeed = "Average Speed:";
            }
            else if(currLanguage == "uk-UA")
            {
                usual = "Text here";
                start = "Старт";
                stop = "Стоп";
                speed = "Швидкість:";
                time = "Час:";
                shortTextInfo = "Дуже короткий текст(хоча би 1000 літер)";
                infoStrip = "F5 - Старт\nQ - Відкрити панель";
                allTimeTraining = "Весь час тренувань:";
                averageSpeed = "Середня швидкість:";
            }
            else
            {
                usual = "Text here";
                start = "Старт";
                stop = "Стоп";
                speed = "Скорость:";
                time = "Время:";
                shortTextInfo = "Очень короткий текст(хотя бы 1000 букв)";
                infoStrip = "F5 - Старт\nQ - Открыть панель";
                allTimeTraining = "Все время тренировок:";
                averageSpeed = "Средняя скорость:";
            }


            allText = TypingField.Text = usual;
            aveSpeed.Text = averageSpeed;
            allTime.Text = allTimeTraining;

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
            aveSpeed.ForeColor = theme.foreColor;
            allTime.ForeColor = theme.foreColor;


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
                    Start.Text = start;
                    return;
                }
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            timerTick.Enabled = !timerTick.Enabled;

            StartTimer.Text = "3";
            StartTimer.Visible = Start.Text == start ? true : false;
            Start.Text = timerTick.Enabled && symbolCount != TypingField.Text.Length ? stop : start;

            if (Start.Text == stop && TypingField.Text != usual)
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
                Time.Text = $"{time} " + timer.ToString();

                Speed.Text = $"{speed} " + ((int)((symbolCount + mistake) / timer.TotalMinutes / 5)).ToString() + "WP";
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
            if (Start.Text == start)
            {
                symbolCount = mistake = mistakePlace = 0;
                Speed.Text = $"{speed} 0WP";
                Time.Text = $"{time} 00:00:00";
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
            MessageBox.Show(infoStrip, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en-US");

            usual = "Text here";
            start = "Start";
            stop = "Stop";
            speed = "Speed:";
            time = "Time:";
            shortTextInfo = "Super short text (al least 1000 letters)";
            infoStrip = "F5 - start\nQ - open panel";
            allTimeTraining = "All time of training:";
            averageSpeed = "Average Speed:";


            Application.Restart();

        }
        private void ukraineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("uk-UA");

            usual = "Text here";
            start = "Старт";
            stop = "Стоп";
            speed = "Швидкість:";
            time = "Час:";
            shortTextInfo = "Дуже короткий текст(хоча би 1000 літер)";
            infoStrip = "F5 - Старт\nQ - Відкрити панель";
            allTimeTraining = "Весь час тренувань:";
            averageSpeed = "Середня швидкість:";

            Application.Restart();
        }
        private void russiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("ru-RU");

            usual = "Text here";
            start = "Старт";
            stop = "Стоп";
            speed = "Скорость:";
            time = "Время:";
            shortTextInfo = "Очень короткий текст(хотя бы 1000 букв)";
            infoStrip = "F5 - Старт\nQ - Открыть панель";
            allTimeTraining = "Все время тренировок:";
            averageSpeed = "Средняя скорость:";

            Application.Restart();
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
                    MessageBox.Show(shortTextInfo, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    allText = usual;
                }

                Reset_Click(Reset, null);
            }
        }
    }
}
