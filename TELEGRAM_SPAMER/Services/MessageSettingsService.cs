using NLog;
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
    public class MessageSettingsService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Configuration configuration;

        private String MeesageStringKey = "MeesageString";
        private String UseStickerKey = "UseSticker";
        private String IDEmojiKey = "IDEmoji";
        private String IDStickerKey = "IDSticker";

        public MessageSettingsService()
        {
            configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
        }

        public void Save(MessageSettings messageSettings)
        {
            configuration.AppSettings.Settings[MeesageStringKey].Value = messageSettings.MeesageString;
            configuration.AppSettings.Settings[UseStickerKey].Value = messageSettings.UseSticker.ToString();
            configuration.AppSettings.Settings[IDEmojiKey].Value = messageSettings.IDEmoji.ToString();
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public MessageSettings Load()
        {
            MessageSettings messageSettings = new MessageSettings();

            String MeesageString;

            try
            {
                MeesageString = configuration.AppSettings.Settings[MeesageStringKey].Value;

                if (String.IsNullOrWhiteSpace(MeesageString))
                {
                    throw new Exception("Значение сообщения отсутвует или не определено");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                MeesageString = String.Empty;
            }

            messageSettings.MeesageString = MeesageString;

            String IDEmoji;

            try
            {
                IDEmoji = configuration.AppSettings.Settings[IDEmojiKey].Value;

                if (String.IsNullOrWhiteSpace(IDEmoji))
                {
                    throw new Exception("Значение ID Эмоджи отсутвует или не определено");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                IDEmoji = String.Empty;
            }

            messageSettings.IDEmoji = IDEmoji;

            Boolean UseSticker;

            try
            {
                UseSticker = Convert.ToBoolean(configuration.AppSettings.Settings[UseStickerKey].Value);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                UseSticker = false;
            }

            messageSettings.UseSticker = UseSticker;

            return messageSettings;
        }
    }
}
