using System.Windows.Forms;

namespace Blind_typing_trainer
{
    internal class NSButton : Button
    {
        public NSButton() : base()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
