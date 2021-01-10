using CefSharp;
using CefSharp.WinForms;
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
    public partial class Browser : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public Browser()
        {
            InitializeComponent();
            InitializeChromium();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.CachePath = Application.StartupPath + @"\Cache";

            Cef.Initialize(settings);

            chromeBrowser = new ChromiumWebBrowser("https://web.telegram.org/#/login");

            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void Browser_Load(object sender, EventArgs e)
        {

        }

        private void Browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!BrowserViewer.IsClose)
            {
                e.Cancel = true;
                BrowserViewer.Hide();
                LogViewer.WriteLog("Скрыть браузер");
                return;
            }

            LogViewer.WriteLog("Закрываем браузер");
        }
    }
}
