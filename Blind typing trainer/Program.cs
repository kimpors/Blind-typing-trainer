using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Blind_typing_trainer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
      {
            var currLanguage = ConfigurationManager.AppSettings["language"];

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(currLanguage);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(currLanguage);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
