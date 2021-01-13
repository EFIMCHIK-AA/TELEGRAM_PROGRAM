using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TELEGRAM_SPAMER.Services;

namespace TELEGRAM_SPAMER
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

            AppManager.Settings = new SettingsService().Load();
            AppManager.MainForm = new ApplicationContext();
            AppManager.MainForm.MainForm = new TELEGRAM_SPAMER.Views.Main();

            Application.Run(AppManager.MainForm);
        }
    }
}
