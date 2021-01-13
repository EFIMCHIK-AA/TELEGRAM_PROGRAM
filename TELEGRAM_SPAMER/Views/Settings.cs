using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TELEGRAM_SPAMER.Services;

namespace TELEGRAM_SPAMER.Views
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingsService settingsService = new SettingsService();

            settingsService.Save(
                new TELEGRAM_SPAMER.Models.Settings
                {
                    BrowserReload = true,
                    Time = Convert.ToInt32(Time_NUD.Value)
                });

            Application.Restart();
            Environment.Exit(0);
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
