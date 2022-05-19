using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Blind_typing_trainer
{
    public class RichLabel : RichTextBox
    {
        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;

        [DefaultValue(true)]
        public bool Selectable { get; set; }

        [DllImport("user32.dll", EntryPoint = "HideCaret")]
        public static extern long HideCaret(IntPtr hwnd);
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0201: //WM_LBUTTONDOWN
                    return;
                case 0x0202: //WM_LBUTTONUP
                    return;
                case 0x0203: //WM_LBUTTONDBLCLK
                    return;
                case 0x0204: //WM_RBUTTONDOWN
                    return;
                case 0x0205: //WM_RBUTTONUP
                    return;
                case 0x0206: //WM_RBUTTONDBLCLK
                    return;
            }

            if (m.Msg == WM_SETFOCUS && !Selectable)
                m.Msg = WM_KILLFOCUS;

            base.WndProc(ref m);
            HideCaret(Handle);
        }

        public RichLabel() : base()
        {
            ReadOnly = Selectable = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            ReadOnly = true;
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            /*            Margins = new Cordinate[TextLength];

                        for (int i = 0; i < TextLength; i++)
                        {
                            Margins[i].x = TextRenderer.MeasureText(Text.Substring(0, i), Font).Width;
                            Margins[i].y = TextRenderer.MeasureText(Text.Substring(0, i), Font).Height;
                        }*/
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!ClientRectangle.Contains(e.Location))
            {
                Capture = false;
            }
            else if (!Capture)
            {
                Capture = true;
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            e.SuppressKeyPress = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Margin.Right
            /*            Rectangle rect = new Rectangle(Location.X + Margin.Right, Location.Y, Size.Width, Size.Height);
                        TextRenderer.DrawText(e.Graphics, Text, Font, rect,
                            ForeColor, BackColor, TextFormatFlags.WordBreak);*/
        }
    }
}
