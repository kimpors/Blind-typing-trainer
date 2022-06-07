using System;
using System.Drawing;
using System.Windows.Forms;

namespace Blind_typing_trainer.MyControls
{
    public partial class MyFontDialog : Form
    {
        FontFamily font;
        FontStyle style;
        float size;
        const int SIZE = 30;
        public Font newFont { get; set; }

        public MyFontDialog(Theme theme, Font currFont)
        {
            InitializeComponent();
            SetTheme(theme);

            foreach (FontFamily ft in FontFamily.Families)
                if (new Font(ft, 10).GdiCharSet == 1)
                    fonts.Items.Add(ft.Name);

            styles.Items.Add(FontStyle.Italic);
            styles.Items.Add(FontStyle.Strikeout);
            styles.Items.Add(FontStyle.Regular);
            styles.Items.Add(FontStyle.Underline);
            styles.Items.Add(FontStyle.Bold);

            for (int i = 1; i < 17; i += 2)
                sizes.Items.Add(i);


            font = currFont.FontFamily;
            fonts.Text = font.Name;

            style = FontStyle.Regular;
            styles.Text = style.ToString();

            size = currFont.Size;
            sizes.Text = size.ToString();
        }

        void SetTheme(Theme theme)
        {
            theme.SetTheme(this);
            Ok.BackColor = theme.backColor;

            fonts.BackColor = theme.backColor;
            fonts.ForeColor = theme.foreColor;

            styles.BackColor = theme.backColor;
            styles.ForeColor = theme.foreColor;

            sizes.BackColor = theme.backColor;
            sizes.ForeColor = theme.foreColor;

            example.Font = new Font(example.Font.FontFamily, SIZE, style);
            panel1.BackColor = theme.backColor;
        }

        void fonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            font = new FontFamily(fonts.Items[fonts.SelectedIndex].ToString());
            example.Font = new Font(font, SIZE, style);
        }
        void styles_SelectedIndexChanged(object sender, EventArgs e)
        {
            style = (FontStyle)styles.Items[styles.SelectedIndex];

            example.Font = new Font(font, SIZE, style);
        }
        void sizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = (int)sizes.Items[sizes.SelectedIndex];
        }

        void Yes_Click(object sender, EventArgs e)
        {
            newFont = new Font(font, size, style);
        }
    }
}
