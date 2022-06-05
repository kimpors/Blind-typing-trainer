using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Blind_typing_trainer
{
    partial class ThemeForm : Form
    {
        User user;
        SaveDialog sd;
        Color back, secondBack, fore;
        Font font, rLFont;
        string name;

        public ThemeForm(User currUser, Theme currTheme)
        {
            InitializeComponent();

            user = currUser;
            sd = new SaveDialog(currTheme);
            SetTheme(currTheme);

            back = currTheme.backColor;
            secondBack = currTheme.secondBackColor;
            fore = currTheme.foreColor;
            font = currTheme.font;
            rLFont = currTheme.typingFieldFont;
        }
        void SetTheme(Theme theme)
        {
            theme.SetTheme(this);

            foreColor.BackColor = theme.secondBackColor;
            backColor.BackColor = theme.secondBackColor;
            secondBackColor.BackColor = theme.secondBackColor;
            SetFont.BackColor = theme.secondBackColor;
            richTextFont.BackColor = theme.secondBackColor;

            theme.SetChartTheme(chart1);
            theme.SetMenuTheme(menuStrip1);
        }
        void StripMenuBackColor(Color color)
        {
            foreach (ToolStripMenuItem a in menuStrip1.Items)
            {
                foreach (ToolStripMenuItem b in a.DropDownItems)
                {
                    b.BackColor = color;

                    foreach (ToolStripMenuItem c in b.DropDownItems)
                    {
                        c.BackColor = color;

                        foreach (ToolStripMenuItem d in b.DropDownItems)
                            d.BackColor = color;
                    }
                }
            }
        }

        void backColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                back = colorDialog1.Color;

                richTextBox1.BackColor = back;
                richTextBox1.SelectAll();
                richTextBox1.SelectionBackColor = back;

                chart1.ChartAreas[0].BackColor = back;

                foreach (Panel pn in Controls.OfType<Panel>())
                    foreach (Button bt in pn.Controls.OfType<Button>())
                        bt.BackColor = back;


                StripMenuBackColor(back);
            }
        }
        void secondBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                secondBack = colorDialog1.Color;

                panel2.BackColor = secondBack;
                menuStrip1.BackColor = secondBack;
                panel1.BackColor = secondBack;
                chart1.BackColor = secondBack;
            }
        }
        void foreColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fore = colorDialog1.Color;
                ForeColor = fore;
                richTextBox1.ForeColor = fore;
                CustomTheme temp = new CustomTheme(back, secondBack, fore, "", font, rLFont);
                temp.SetTheme(this);
                temp.SetMenuTheme(menuStrip1);
            }
        }
        void font_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog1.Font;

                foreach (Panel pn in Controls.OfType<Panel>())
                    foreach (Control ct in pn.Controls)
                        if (ct is Button || ct is Label)
                            ct.Font = font;

                foreach (ToolStripMenuItem a in menuStrip1.Items)
                {
                    a.Font = font;
                    foreach (ToolStripMenuItem b in a.DropDownItems)
                    {
                        b.Font = font;

                        foreach (ToolStripMenuItem c in b.DropDownItems)
                            c.Font = font;
                    }
                }
            }
        }
        void richTextFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = rLFont = fontDialog1.Font;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (panel1.Visible)
                panelShow_Click(panelShow, null);
        }

        void panelShow_Click(object sender, EventArgs e)
        {
            panel2.Visible = panel1.Visible = !panel1.Visible;

            chart1.Series[0].Points.Clear();
            foreach (float run in user.allRuns)
                chart1.Series[0].Points.AddY(run);
        }
        void save_Click(object sender, EventArgs e)
        {
            sd = new SaveDialog(new CustomTheme(back, secondBack, fore, "", font, rLFont));

            if (sd.ShowDialog() == DialogResult.Yes)
            {
                name = sd.result;

                if (user.allThemes.Count < 10)
                    user.allThemes.Add(new CustomTheme(back, secondBack, fore, name, font, rLFont));

                Close();
            }
        }
    }
}
