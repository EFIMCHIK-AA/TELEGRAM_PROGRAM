using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TELEGRAM_SPAMER.Models;

namespace TELEGRAM_SPAMER.Services
{
    public class SettingsService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Configuration configuration;

        private String TimeKey = "Time";
        private String BrowserReloadKey = "BrowserReload";

        public SettingsService()
        {
            configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
        }

        public void Save(Settings settings)
        {
            configuration.AppSettings.Settings[TimeKey].Value = settings.Time.ToString();
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void SetBrowserReload(Boolean state)
        {
            configuration.AppSettings.Settings[BrowserReloadKey].Value = state.ToString();
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public Settings Load()
        {
            Settings setting = new Settings();

            int Time;

            try
            {
                Time = Convert.ToInt32(configuration.AppSettings.Settings[TimeKey].Value);

                if (Time < 1 || Time > 5000000)
                {
                    throw new Exception("Значние времени инъекции не попадает в указанный дипазон");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                Time = 10000;
            }

            setting.Time = Time;

            Boolean BrowserReload;

            try
            {
                BrowserReload = Convert.ToBoolean(configuration.AppSettings.Settings[BrowserReloadKey].Value);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                BrowserReload = false;
            }

            setting.BrowserReload = BrowserReload;

            return setting;
        }
    }
}
