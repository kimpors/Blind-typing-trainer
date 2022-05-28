using System.Drawing;
using System.Windows.Forms;
using System;

namespace Blind_typing_trainer
{
    [Serializable]
    public abstract class Theme
    {
        public Theme() { }

        public Theme(Color back, Color secondBack, Color fore)
        {
            backColor = back;
            foreColor = fore;
            secondBackColor = secondBack;
        }
        public Theme(Theme th)
        {
            backColor = th.backColor;
            foreColor = th.foreColor;
            secondBackColor = th.secondBackColor;
        }

        public virtual Color backColor { get; }
        public virtual Color foreColor { get; }
        public virtual Color secondBackColor { get; }

        public ProfessionalColorTable CreateColorStrip()
        {
            return new ThemeColorStrip(backColor);
        }
        private sealed class ThemeColorStrip : ProfessionalColorTable
        {
            private Color back;

            public ThemeColorStrip(Color back)
            {
                this.back = back;
            }

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
        public CustomTheme(Theme th, string name) : base(th)
        {
            Name = name;
        }
        public CustomTheme(Color back, Color secondBack, Color fore, string name) : base(back, secondBack, fore)
        {
            Name = name;
        }
    }


    [Serializable]
    public sealed class Light : Theme
    {
        public override Color backColor => Color.FromArgb(202, 207, 255);
        public override Color foreColor => Color.FromArgb(66, 72, 128);
        public override Color secondBackColor => Color.FromArgb(159, 167, 255);

    }
    [Serializable]
    public sealed class Dark : Theme
    {

        public override Color backColor => Color.FromArgb(45, 48, 78);
        public override Color foreColor => Color.FromArgb(193, 196, 226);
        public override Color secondBackColor => Color.FromArgb(77, 80, 112);
    }


    public interface ISwitchTheme
    {
        Theme SwitchDark();
        Theme SwitchLight();
    }

    class SwitchTheme : ISwitchTheme
    {
        public Theme SwitchDark()
        {
            return new Dark();
        }

        public Theme SwitchLight()
        {
            return new Light();
        }
    }
}
