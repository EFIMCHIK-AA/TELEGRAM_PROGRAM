using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TELEGRAM_INVITER.Models;

namespace TELEGRAM_INVITER.Services
{
    public class SettingsService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Configuration configuration;

        private String UseGroupWaitKey = "UseGroupWait";
        private String CountGroupKey = "CountGroup";
        private String TimeGroupKey = "TimeGroup";
        private String TimeKey = "Time";
        private String BrowserReloadKey = "BrowserReload";

        public SettingsService ()
        {
            configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
        }

        public void Save(Settings settings)
        {
            configuration.AppSettings.Settings[UseGroupWaitKey].Value = settings.UseGroupWait.ToString();
            configuration.AppSettings.Settings[CountGroupKey].Value = settings.CountGroup.ToString();
            configuration.AppSettings.Settings[TimeGroupKey].Value = settings.TimeGroup.ToString();
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

            Boolean UseGroupWait;

            try
            {
                UseGroupWait = Convert.ToBoolean(configuration.AppSettings.Settings[UseGroupWaitKey].Value);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                UseGroupWait = false;
            }

            setting.UseGroupWait = UseGroupWait;

            int CountGroup;

            try
            {
                CountGroup = Convert.ToInt32(configuration.AppSettings.Settings[CountGroupKey].Value);

                if(CountGroup < 1 || CountGroup > 200000)
                {
                    throw new Exception("Значние количество инъекций в группе не попадает в указанный дипазон");
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                CountGroup = 5;
            }

            setting.CountGroup = CountGroup;

            int TimeGroup;

            try
            {
                TimeGroup = Convert.ToInt32(configuration.AppSettings.Settings[TimeGroupKey].Value);

                if (TimeGroup < 1 || TimeGroup > 5000000)
                {
                    throw new Exception("Значние времени инъекций в группе не попадает в указанный дипазон");
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                TimeGroup = 20000;
            }

            setting.TimeGroup = TimeGroup;

            int Time;

            try
            {
                Time = Convert.ToInt32(configuration.AppSettings.Settings[TimeKey].Value);

                if (Time < 1 || Time > 5000000)
                {
                    throw new Exception("Значние времени инъекции не попадает в указанный дипазон");
                }
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                BrowserReload = false;
            }

            setting.BrowserReload = BrowserReload;

            return setting;
        }
    }
}
