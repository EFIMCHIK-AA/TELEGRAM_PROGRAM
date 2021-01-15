using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TELEGRAM_SPAMER.Services;

namespace TELEGRAM_SPAMER.Views
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
            String path = Application.StartupPath + @"\Cache";

            if(AppManager.Settings.BrowserReload)
            {
                if(Directory.Exists(path))
                {
                    Directory.Delete(path);
                    new SettingsService().SetBrowserReload(false);
                }
            }

            settings.CachePath = path;

            Cef.Initialize(settings);

            chromeBrowser = new ChromiumWebBrowser("https://web.telegram.org/#/login");
            chromeBrowser.Margin = new Padding(0, 0, 0, 0);
            chromeBrowser.TabIndex = 1;

            Table_TLP.Controls.Add(chromeBrowser,0,1);
            chromeBrowser.Dock = DockStyle.Fill;

            chromeBrowser.ConsoleMessage += ChromeBrowser_ConsoleMessage;
            chromeBrowser.AddressChanged += ChromeBrowser_AddressChanged;
        }

        private void ChromeBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            URL_TB.Invoke(new Action(() =>
            {
                URL_TB.Text = "Ссылка | " + e.Address;
            }));
        }

        private void ChromeBrowser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            ConsoleLogViewer.WriteLog(e.Message);

            Spamer.SetLogConsole(e.Message);
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
                return;
            }
        }
    }
}
