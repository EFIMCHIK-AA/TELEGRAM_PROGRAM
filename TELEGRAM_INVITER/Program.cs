using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TELEGRAM_INVITER.Services;
using TELEGRAM_INVITER.Views;

namespace TELEGRAM_INVITER
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppManager.MainForm = new ApplicationContext();
            AppManager.MainForm.MainForm = new Main();

            Application.Run(AppManager.MainForm);
        }
    }
}
