using System.Drawing;
using System.Windows.Forms;

namespace Blind_typing_trainer
{
    public abstract class Theme
    {
        public virtual Color backColor { get; }
        public virtual Color foreColor { get; }
        public virtual Color darkBackColor { get; }

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

    public sealed class Light : Theme
    {
        public override Color backColor => Color.FromArgb(202, 207, 255);
        public override Color foreColor => Color.FromArgb(66, 72, 128);
        public override Color darkBackColor => Color.FromArgb(159, 167, 255);

    }

    public sealed class Dark : Theme
    {
        public override Color backColor => Color.FromArgb(45, 48, 78);
        public override Color foreColor => Color.FromArgb(193, 196, 226);
        public override Color darkBackColor => Color.FromArgb(77, 80, 112);
    }

    public abstract class FabricTheme
    {
        public abstract Theme CreateTheme();
    }

    public sealed class FabricLight : FabricTheme
    {
        public override Theme CreateTheme()
        {
            return new Light();
        }
    }

    public sealed class FabricDark : FabricTheme
    {
        public override Theme CreateTheme()
        {
            return new Dark();
        }
    }
}
