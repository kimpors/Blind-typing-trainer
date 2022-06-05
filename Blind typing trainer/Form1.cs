using System;
using System.IO;
using System.Net;
using System.Linq;
using NLipsum.Core;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace Blind_typing_trainer
{
    public partial class Form1 : Form
    {
        int symbolCount, mistakeCount, mistakePos;
        double raceResult;
        string allText;
        TimeSpan timer;

        readonly User user;
        Theme currTheme;
        ILanguage currLanguage;

        Rectangle origFormSize;
        float origTypingFieldFontSize;

        const int NOTHING = -1, MAX = 700;
        const string StartTyping = "GO!!!";

        WebClient client;
        string clientTxt;

        public Form1()
        {
            InitializeComponent();

            // User
            using (Stream file = File.Open("User.dat", FileMode.OpenOrCreate))
                if (file.Length > 0)
                    user = (User)new BinaryFormatter().Deserialize(file);

            if (user == null)
            {
                user = new User(new SwitchTheme().SwitchLight(),
                    new SwitchLanguage().SwitchEng(),
                    new TimeSpan(0, 0, 0), new List<float>() { 0 },
                    new List<CustomTheme> {
                        new CustomTheme(new SwitchTheme().SwitchLight(),"Light"),
                        new CustomTheme(new SwitchTheme().SwitchDark(),"Dark")});
            }

            // Form
            symbolCount = mistakeCount = 0;
            mistakePos = NOTHING;

            currLanguage = user.currLanguage;
            allText = TypingField.Text = currLanguage.Standart;
            currTheme = user.currTheme;

            Reset.Image = null;
            Font = currTheme.font;
            panel1.Font = currTheme.font;

            client = new WebClient();
            timer = new TimeSpan(0, 0, 0);
            origFormSize = new Rectangle(Location, Size);
            origTypingFieldFontSize = currTheme.typingFieldFont.Size;

            SetTheme();

            // Language
            string currentLanguage = ConfigurationManager.AppSettings["language"];
            if (currentLanguage == "en-US")
                currLanguage = new SwitchLanguage().SwitchEng();
            else if (currentLanguage == "uk-UA")
                currLanguage = new SwitchLanguage().SwitchUkr();
            else
                currLanguage = new SwitchLanguage().SwitchRus();

            // Stats
            aveSpeed.Text = currLanguage.AverageSpeed + " " + user.allRuns.Average().ToString(".00");
            allTime.Text = currLanguage.AllTimeOfTraining + " " + user.trainingTime.ToString();
            record.Text = "Record: " + user.allRuns.Max().ToString(".00");

            chart1.Series[0].Points.Clear();
            foreach (var item in user.allRuns)
                chart1.Series[0].Points.AddY(item);
        }
        void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                float xRatio = ClientRectangle.Width / (float)origFormSize.Width;
                float yRatio = ClientRectangle.Height / (float)origFormSize.Height;

                float newFontSize = xRatio >= yRatio ? origTypingFieldFontSize * yRatio : origTypingFieldFontSize * xRatio;
                TypingField.Font = new Font(TypingField.Font.FontFamily, newFontSize);
            }
        }
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (StartTimer.Text == StartTyping)
            {
                if (symbolCount == TypingField.Text.Length) symbolCount--;

                if (e.KeyChar == '\b')
                {
                    if (symbolCount > 0)
                    {
                        mistakeCount++;
                        symbolCount--;

                        if (symbolCount == mistakePos) mistakePos = NOTHING;

                        SetTheme();
                        PaintLetters();
                    }
                    return;
                }
                else if (e.KeyChar != TypingField.Text[symbolCount])
                {
                    mistakePos = mistakePos == NOTHING ? symbolCount : mistakePos;
                    mistakeCount++;
                }

                symbolCount++;
                PaintLetters();

                if (symbolCount == TypingField.Text.Length && mistakePos == NOTHING)
                {
                    timerTick.Enabled = false;
                    Start.Text = currLanguage.Start;
                    user.trainingTime = user.trainingTime.Add(timer);
                    user.allRuns.Add((float)raceResult);
                    timer = new TimeSpan(0, 0, 0);
                    return;
                }
            }
        }
        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
                Start_Click(Start, null);
            else if (e.KeyData == Keys.Q && Start.Text == "Start")
                panelShow_Click(panelShow, null);
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            user.currLanguage = currLanguage;
            user.currTheme = currTheme;

            using (Stream file = File.Open("User.dat", FileMode.Open))
                new BinaryFormatter().Serialize(file, user);
        }


        void SetTheme()
        {
            currTheme.SetTheme(this);
            currTheme.SetChartTheme(chart1);
            currTheme.SetMenuTheme(menuStrip1);

            Reset.BackColor = Color.Transparent;
            StartTimer.ForeColor = ForeColor;
            StartTimer.BackColor = currTheme.backColor;

            Form1_Resize(this, null);
        }
        void PaintLetters()
        {
            if (symbolCount > 0)
            {
                TypingField.Select(0, mistakePos != NOTHING ? mistakePos : symbolCount);
                TypingField.SelectionColor = Color.LimeGreen;
            }


            if (mistakePos != NOTHING)
            {
                TypingField.Select(mistakePos, mistakePos != NOTHING ? symbolCount - mistakePos : symbolCount);
                TypingField.SelectionBackColor = Color.Red;
            }
        }
        void ChangeLanguage(string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["language"].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }
        void SelectThemeRender()
        {
            themeSelectToolStripMenuItem.DropDownItems.Clear();

            foreach (CustomTheme ct in user.allThemes)
                themeSelectToolStripMenuItem.DropDownItems.Add(ct.Name);


            foreach (ToolStripMenuItem th in themeSelectToolStripMenuItem.DropDownItems)
            {
                th.Click += new EventHandler(Th_Click);

                if (th.Text != "Light" && th.Text != "Dark")
                {
                    th.DropDownItems.Add("Delete");
                    currTheme.SetMenuItemTheme(th);

                    foreach (ToolStripMenuItem del in th.DropDownItems)
                    {
                        del.Click += new EventHandler(Del_Click);
                    }
                }
            }
        }

        void panelShow_Click(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                aveSpeed.Text = currLanguage.AverageSpeed + " " + user.allRuns.Average().ToString(".00");
                allTime.Text = currLanguage.AllTimeOfTraining + " " + user.trainingTime;
                record.Text = "Record: " + user.allRuns.Max().ToString(".00");

                chart1.Series[0].Points.Clear();
                foreach (var item in user.allRuns)
                    chart1.Series[0].Points.AddY(item);
            }
            panel1.Visible = !panel1.Visible;
            panel2.Visible = panel1.Visible;
        }
        void Start_Click(object sender, EventArgs e)
        {
            Reset_Click(Reset, null);
            panel1.Visible = false;
            panel2.Visible = panel1.Visible;

            timerTick.Enabled = !timerTick.Enabled;

            StartTimer.Text = "3";
            StartTimer.Visible = Start.Text == currLanguage.Start;
            Start.Text = timerTick.Enabled && symbolCount != TypingField.Text.Length ? currLanguage.Stop : currLanguage.Start;

            if (Start.Text == currLanguage.Stop && allText != currLanguage.Standart)
                TypingField.Text = Regex.Match(allText.Substring(new Random()
                    .Next(1, allText.Length - 1000)).Replace("  ", ""), @"[A-Z]+.{100,1000}\.").Value;
        }
        void Reset_Click(object sender, EventArgs e)
        {
            if (Start.Text == currLanguage.Start)
            {
                symbolCount = mistakeCount = 0;
                mistakePos = NOTHING;
                Speed.Text = $"{currLanguage.Speed} 0WP";
                Time.Text = $"{currLanguage.Time} 00:00:00";
                SetTheme();
                Form1_Resize(this, null);
            }
        }
        void Del_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)sender).OwnerItem.Text;

            foreach (CustomTheme th in user.allThemes)
            {
                if (th.Name == name && name != "Light" && name != "Dark")
                {
                    user.allThemes.Remove(th);
                    currTheme = user.allThemes[0];
                    SelectThemeRender();
                    SetTheme();
                    return;
                }
            }
        }
        void Th_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)sender).Text;

            foreach (CustomTheme th in user.allThemes)
            {
                if (name == th.Name)
                {
                    currTheme = th;
                    SelectThemeRender();
                    SetTheme();
                    return;
                }
            }
        }

        void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en-US");
            currLanguage = new SwitchLanguage().SwitchEng();
            Application.Restart();
        }
        void ukraineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("uk-UA");
            currLanguage = new SwitchLanguage().SwitchUkr();
            Application.Restart();
        }
        void russiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("ru-RU");
            currLanguage = new SwitchLanguage().SwitchRus();
            Application.Restart();
        }

        void openToolStripMenuItem_Click(object sender, EventArgs e)
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
                Form1_Resize(this, null);
            }
        }
        void loremIpsumGenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypingField.Text = string.Join("", new LipsumGenerator().GenerateSentences(new Random().Next(5, 13)));
        }
        void onlineGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientTxt = client.DownloadString($"https://data.typeracer.com/pit/text_info?id={new Random().Next(1, MAX)}");

            clientTxt = Regex.Match(clientTxt, @"fullTextStr.*</div>").Value
                .Replace(@"fullTextStr"">", "").Replace("</div>", "");
            TypingField.Text = clientTxt;
        }

        void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoDialog id = new InfoDialog(currTheme);
            id.ShowDialog();
        }
        void themeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemeForm ft = new ThemeForm(user, currTheme);
            if (Application.OpenForms["ThemeForm"] == null)
                ft.Show();
        }
        void themeSelectToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (themeSelectToolStripMenuItem.DropDownItems.Count < user.allThemes.Count)
            {
                SelectThemeRender();
                SetTheme();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (StartTimer.Text == StartTyping)
            {
                StartTimer.Visible = false;

                timer = timer.Add(new TimeSpan(0, 0, 1));
                Time.Text = $"{currLanguage.Time} " + timer.ToString();

                raceResult = (symbolCount + mistakeCount) / timer.TotalMinutes / 5;
                Speed.Text = $"{currLanguage.Speed} " + ((int)raceResult).ToString() + "WP";
            }
            else 
            { StartTimer.Text = StartTimer.Text != "1" ? (int.Parse(StartTimer.Text) - 1).ToString() : StartTyping; }
        }
    }
}
