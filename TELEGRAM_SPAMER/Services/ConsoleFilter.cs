﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TELEGRAM_SPAMER.Services
{
    public class ConsoleFilter
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public (String, Boolean) GetResult(String Message)
        {
            if (Message.Contains("{TL_Spamer} - "))
            {
                String[] TempMessage = Message.Split('.');

                if (TempMessage != null)
                {
                    if (TempMessage.Length == 2 && (TempMessage[1].Contains("Критическая ошибка") || TempMessage[1].Contains("Проверьте наличие прав")))
                    {
                        logger.Error(Message);
                        return (Message.Split('-')[1].Trim(), true);
                    }

                    if (TempMessage.Length == 1)
                    {
                        logger.Error(Message);
                        return (Message.Split('-')[1].Trim(), false);
                    }
                }
            }
            else
            {
                if (Message.Contains("403 USER_PRIVACY_RESTRICTED"))
                {
                    return ("Отключена возможность приглашения", false);
                }

                if (Message.Contains("400 PEER_FLOOD"))
                {
                    return ("Telegram API обнаружил \"Спам\". Запрос заблокирован", true);
                }

                if (Message.Contains("400 USER_NOT_MUTUAL_CONTACT"))
                {
                    return ("Разрешено приглашать только контактам", false);
                }
                
                if (Message.Contains("400 USERNAME_NOT_OCCUPIED"))
                {
                    return ("Пользователь не найден", false);
                }

                if (Message.Contains("403 INPUT_USER_DEACTIVATED"))
                {
                    return ("Пользователь удален или деактивирован", false);
                }
            }

            return (null, false);
        }
    }
}
