using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Blind_typing_trainer
{
    partial class ThemeForm : Form
    {
        User user;
        Color back, secondBack, fore;
        string name;


        public ThemeForm(User currUser, Theme currTheme, ILanguage currLanguage)
        {
            InitializeComponent();

            string currentLanguage = ConfigurationManager.AppSettings["language"];

            if (currentLanguage == "en-US")
                currLanguage = new SwitchLanguage().SwitchEng();
            else if (currentLanguage == "uk-UA")
                currLanguage = new SwitchLanguage().SwitchUkr();
            else
                currLanguage = new SwitchLanguage().SwitchRus();

            user = currUser;

            back = currTheme.backColor;
            secondBack = currTheme.secondBackColor;
            fore = currTheme.foreColor;

            chart1.Series[0].Points.Clear();
            foreach (var item in user.allRuns)
            {
                chart1.Series[0].Points.AddY(item);
            }

            menuStrip1.Renderer = new ToolStripProfessionalRenderer(currTheme.CreateColorStrip());

            menuStrip1.BackColor = currTheme.secondBackColor;
            menuStrip1.ForeColor = currTheme.foreColor;

            StripMenuForeColor(currTheme.foreColor);


            BackColor = currTheme.secondBackColor;

            richTextBox1.BackColor = currTheme.backColor;
            richTextBox1.ForeColor = currTheme.foreColor;

            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = currTheme.backColor;
            richTextBox1.SelectionColor = currTheme.foreColor;

            foreach (var item in panel1.Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    ((Label)item).ForeColor = currTheme.foreColor;
                }
                else if (item.GetType() == typeof(NSButton))
                {
                    ((NSButton)item).ForeColor = currTheme.foreColor;
                    ((NSButton)item).BackColor = currTheme.secondBackColor;
                }
                else if (item.GetType() == typeof(Button))
                {
                    ((Button)item).ForeColor = currTheme.foreColor;
                    ((Button)item).BackColor = currTheme.backColor;
                }
            }


            chart1.BackColor = currTheme.secondBackColor;
            chart1.Series[0].Color = currTheme.foreColor;

            chart1.ChartAreas[0].BackColor = currTheme.backColor;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = currTheme.foreColor;
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = currTheme.foreColor;
            chart1.ChartAreas[0].AxisX.LineColor = currTheme.foreColor;

            chart1.ChartAreas[0].AxisY.LineColor = currTheme.foreColor;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = currTheme.foreColor;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = currTheme.foreColor;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = panel1.Visible = !panel1.Visible;
            if (panel1.Visible)
                button5.Text = "Hide";
            else
                button5.Text = "Show";

            chart1.Series[0].Points.Clear();
            foreach (var item in user.allRuns)
            {
                chart1.Series[0].Points.AddY(item);
            }
        }
        private void backColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                back = color;

                richTextBox1.BackColor = color;
                chart1.ChartAreas[0].BackColor = colorDialog1.Color;

                foreach (var pn in Controls.OfType<Panel>())
                {
                    foreach (var item in pn.Controls.OfType<Button>())
                    {
                        item.BackColor = color;
                    }
                }

                StripMenuBackColor(color);
            }
        }

        private void StripMenuBackColor(Color color)
        {
            foreach (ToolStripMenuItem a in menuStrip1.Items)
            {
                foreach (ToolStripMenuItem b in a.DropDownItems)
                {
                    b.BackColor = color;

                    if (b.HasDropDown)
                    {
                        foreach (ToolStripMenuItem c in b.DropDownItems)
                        {
                            c.BackColor = color;

                            if (c.HasDropDown)
                            {
                                foreach (ToolStripMenuItem d in b.DropDownItems)
                                    d.BackColor = color;
                            }
                        }
                    }
                }
            }
        }
        private void StripMenuForeColor(Color color)
        {
            foreach (ToolStripMenuItem a in menuStrip1.Items)
            {
                a.ForeColor = color;
                foreach (ToolStripMenuItem b in a.DropDownItems)
                {
                    b.ForeColor = color;
                    if (b.HasDropDown)
                    {
                        foreach (ToolStripMenuItem c in b.DropDownItems)
                            c.ForeColor = color;
                    }
                }
            }
        }


        private void secondBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                secondBack = color;

                panel3.BackColor = color;
                menuStrip1.BackColor = color;
                panel1.BackColor = color;

                chart1.BackColor = color;
            }
        }

        private void foreColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                fore = color;

                ForeColor = color;

                StripMenuForeColor(color);

                chart1.Series[0].Color = colorDialog1.Color;

                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = colorDialog1.Color;
                chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = colorDialog1.Color;
                chart1.ChartAreas[0].AxisX.LineColor = colorDialog1.Color;

                chart1.ChartAreas[0].AxisY.LineColor = colorDialog1.Color;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = colorDialog1.Color;
                chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = colorDialog1.Color;
            }
        }

        private void Font_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font font = fontDialog1.Font;


                foreach (var pn in Controls.OfType<Panel>())
                {
                    foreach (var item in pn.Controls)
                    {
                        if (item is Button)
                        {
                            ((Button)item).Font = font;
                        }
                        else if (item is Label)
                        {
                            ((Label)item).Font = font;
                        }
                    }
                }

                foreach (ToolStripMenuItem a in menuStrip1.Items)
                {
                    a.Font = font;
                    foreach (var b in a.DropDownItems)
                    {
                        ((ToolStripMenuItem)b).Font = font;

                        foreach (var c in ((ToolStripMenuItem)b).DropDownItems)
                        {
                            ((ToolStripMenuItem)c).Font = font;
                        }
                    }
                }
            }
        }

        private void nsButton1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        private void richTextFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font font = fontDialog1.Font;

                richTextBox1.Font = font;
            }
        }

        private void ThemeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (user.allThemes.Count < 10 && name != null)
                user.allThemes.Add(new CustomTheme(back, secondBack, fore, name == null ? "UserTheme" : name));
        }
    }
}
