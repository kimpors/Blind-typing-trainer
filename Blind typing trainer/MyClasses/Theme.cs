using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Blind_typing_trainer
{
    [Serializable]
    public abstract class Theme
    {
        public Theme() { }
        public Theme(Color back, Color secondBack, Color fore, Font font, Font TypingFieldFont)
        {
            backColor = back;
            foreColor = fore;
            secondBackColor = secondBack;
            this.font = font;
            this.typingFieldFont = TypingFieldFont;
        }
        public Theme(Theme th)
        {
            backColor = th.backColor;
            foreColor = th.foreColor;
            secondBackColor = th.secondBackColor;
            font = th.font;
            typingFieldFont = th.typingFieldFont;
        }

        public virtual Color backColor { get; }
        public virtual Color foreColor { get; }
        public virtual Color secondBackColor { get; }
        public virtual Font font { get; }
        public virtual Font typingFieldFont { get; }

        public void SetTheme(Form f)
        {
            f.BackColor = secondBackColor;
            f.ForeColor = foreColor;
            f.Font = font;

            List<Panel> panel = f.Controls.OfType<Panel>().ToList();
            foreach (Panel pn in panel)
            {
                foreach (Control ct in pn.Controls)
                {
                    if (ct is Label)
                    {
                        ct.ForeColor = foreColor;
                        ct.Font = font;
                    }
                    else if (ct is NSButton)
                    {
                        ct.ForeColor = foreColor;
                        ct.BackColor = backColor;
                        ct.Font = font;
                    }
                }
            }

            List<RichLabel> richLabels = f.Controls.OfType<RichLabel>().ToList();
            foreach (RichLabel rl in richLabels)
            {
                rl.BackColor = backColor;
                rl.ForeColor = foreColor;
                rl.Font = typingFieldFont;
            }

            List<RichTextBox> richTextBox = f.Controls.OfType<RichTextBox>().ToList();
            foreach (RichTextBox rb in richTextBox)
            {
                rb.BackColor = backColor;
                rb.ForeColor = foreColor;
                rb.Font = font;

                rb.SelectAll();
                rb.SelectionBackColor = backColor;
                rb.SelectionColor = foreColor;
            }

            List<MenuStrip> menuStrips = f.Controls.OfType<MenuStrip>().ToList();
            foreach (MenuStrip ms in menuStrips)
            {
                ms.Renderer = new ToolStripProfessionalRenderer(CreateColorStrip());
                ms.BackColor = secondBackColor;
                ms.ForeColor = foreColor;
                ms.Font = new Font(font.FontFamily, font.Size - 3);

                foreach (ToolStripMenuItem a in ms.Items)
                {
                    a.ForeColor = foreColor;
                    foreach (ToolStripMenuItem b in a.DropDownItems)
                    {
                        b.ForeColor = foreColor;

                        if (b.HasDropDown)
                            foreach (ToolStripMenuItem c in b.DropDownItems)
                                c.ForeColor = foreColor;
                    }
                }
            }
        }
        public void SetChartTheme(Chart ch)
        {
            ch.BackColor = secondBackColor;
            ch.ForeColor = foreColor;

            ch.Series[0].Color = foreColor;
            ch.ChartAreas[0].BackColor = backColor;

            ch.ChartAreas[0].AxisX.MajorGrid.LineColor = foreColor;
            ch.ChartAreas[0].AxisX.LabelStyle.ForeColor = foreColor;
            ch.ChartAreas[0].AxisX.LineColor = foreColor;

            ch.ChartAreas[0].AxisY.LineColor = foreColor;
            ch.ChartAreas[0].AxisY.MajorGrid.LineColor = foreColor;
            ch.ChartAreas[0].AxisY.LabelStyle.ForeColor = foreColor;
        }
        public void SetMenuItemTheme(ToolStripMenuItem tsm)
        {
            foreach (ToolStripMenuItem ts in tsm.DropDownItems)
            {
                ts.ForeColor = foreColor;
                ts.BackColor = backColor;
                ts.Font = font;
            }
        }
        public void SetMenuTheme(MenuStrip ms)
        {
            ms.Renderer = new ToolStripProfessionalRenderer(CreateColorStrip());
            ms.BackColor = secondBackColor;
            ms.ForeColor = foreColor;
            ms.Font = font;

            foreach (ToolStripMenuItem a in ms.Items)
            {
                a.ForeColor = foreColor;
                foreach (ToolStripMenuItem b in a.DropDownItems)
                {
                    b.ForeColor = foreColor;
                    if (b.HasDropDown)
                    {
                        foreach (ToolStripMenuItem c in b.DropDownItems)
                        {
                            c.ForeColor = foreColor;
                        }
                    }
                }
            }
        }
        public void SetPanelTheme(Panel pn)
        {
            foreach (Control ct in pn.Controls)
            {
                if (ct is Label)
                {
                    ct.ForeColor = foreColor;
                }
                else if (ct is NSButton)
                {
                    ct.ForeColor = foreColor;
                    ct.BackColor = backColor;
                }
            }
        }

        public ProfessionalColorTable CreateColorStrip()
        {
            return new ThemeColorStrip(backColor);
        }
        private sealed class ThemeColorStrip : ProfessionalColorTable
        {
            private readonly Color back;

            public ThemeColorStrip(Color back) { this.back = back; }

            public override Color ToolStripDropDownBackground { get { return back; } }
            public override Color ImageMarginGradientBegin { get { return back; } }
            public override Color ImageMarginGradientEnd { get { return back; } }
            public override Color ImageMarginGradientMiddle { get { return back; } }
            public override Color MenuItemSelectedGradientBegin { get { return back; } }
            public override Color MenuItemSelectedGradientEnd { get { return back; } }
            public override Color MenuItemPressedGradientBegin { get { return back; } }
            public override Color MenuItemPressedGradientMiddle { get { return back; } }
            public override Color MenuItemPressedGradientEnd { get { return back; } }
            public override Color MenuItemBorder { get { return back; } }
        }
    }

    [Serializable]
    public class CustomTheme : Theme
    {
        public string Name { get; set; }
        public CustomTheme(Theme th, string name) : base(th) { Name = name; }
        public CustomTheme(Color back, Color secondBack, Color fore, string name, Font f, Font TypingFieldFont)
            : base(back, secondBack, fore, f, TypingFieldFont) { Name = name; }
    }


    [Serializable]
    public sealed class Light : Theme
    {
        public override Color backColor => Color.FromArgb(202, 207, 255);
        public override Color foreColor => Color.FromArgb(66, 72, 128);
        public override Color secondBackColor => Color.FromArgb(159, 167, 255);

        public override Font font => new Font("Calibri", 12f);
        public override Font typingFieldFont => new Font("Calibri", 13.5f);
    }
    [Serializable]
    public sealed class Dark : Theme
    {
        public override Color backColor => Color.FromArgb(45, 48, 78);
        public override Color foreColor => Color.FromArgb(193, 196, 226);
        public override Color secondBackColor => Color.FromArgb(77, 80, 112);

        public override Font font => new Font("Calibri", 12f);
        public override Font typingFieldFont => new Font("Calibri", 13.5f);
    }


    public interface ISwitchTheme
    {
        Theme SwitchDark();
        Theme SwitchLight();
    }
    class SwitchTheme : ISwitchTheme
    {
        public Theme SwitchDark() { return new Dark(); }
        public Theme SwitchLight() { return new Light(); }
    }
}
