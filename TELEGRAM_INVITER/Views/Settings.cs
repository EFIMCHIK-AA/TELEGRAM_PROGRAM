using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TELEGRAM_INVITER.Services;

namespace TELEGRAM_INVITER.Views
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void UserWait_CB_CheckedChanged(object sender, EventArgs e)
        {
            CoundUser_NUD.Enabled = UseGroupWait_CB.Checked;
            TimeGroup_NUD.Enabled = UseGroupWait_CB.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingsService settingsService = new SettingsService();

            settingsService.Save(
                new Models.Settings
                {
                    UseGroupWait = UseGroupWait_CB.Checked,
                    CountGroup = Convert.ToInt32(CoundUser_NUD.Value),
                    BrowserReload = true,
                    TimeGroup = Convert.ToInt32(TimeGroup_NUD.Value),
                    Time = Convert.ToInt32(Time_NUD.Value)
                });

            Application.Restart();
            Environment.Exit(0);
        }
    }
}
