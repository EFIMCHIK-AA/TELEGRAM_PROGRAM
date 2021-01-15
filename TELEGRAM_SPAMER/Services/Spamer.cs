using CefSharp;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TELEGRAM_SPAMER.Exceptions;

namespace TELEGRAM_SPAMER.Services
{
    public class Spamer
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static Boolean IsWork = false;

        private void StopWork()
        {
            if (!IsWork)
            {
                logger.Info("Выполнение работы отменено");
                throw new StopWorkException("Выполнение работы отменено");
            }
        }

        private String GetScriptSticker(String ID_Emoji)
        {
            return @"function Delay(ms){return new Promise((function(resolve,reject){setTimeout(resolve,ms)}))}async function SpamMessage(ID_Emoji){var prefix='{TL_Spamer} - ';if(IsEmpty(ID_Emoji))return console.log(prefix+'Получен пустой идентификатор эмоджи для отправки. Критическая ошибка'),'Получен пустой идентификатор эмоджи для отправки. Критическая ошибка';var resultMessageInput=GetMessageInput(),resultClieckSendMessage;return null==resultMessageInput?(console.log(prefix+'Ошибка при поиске окна ввода сообщения. Критическая ошибка'),'Ошибка при поиске окна ввода сообщения. Критическая ошибка'):($(resultMessageInput).trigger('keydown'),resultMessageInput.innerHTML=ID_Emoji,$(resultMessageInput).trigger('keyup'),await Delay(300),null==ClickOnSendButton()?(console.log(prefix+'Ошибка при нажатии на кнопку отправки стикера. Критическая ошибка'),'Ошибка при нажатии на кнопку отправки стикера. Критическая ошибка'):(console.log(prefix+'Стикер успешно отправлен'),'Стикер успешно отправлен'))}function GetMessageInput(){var MessageInput=GetElementByTagAndClassFromDocument('div','composer_rich_textarea');return null!=MessageInput?MessageInput:null}function ClickOnSendButton(){var SendButton=GetElementByTagAttributeAttributeFromDocument('ng-switch-when','a','sticker','data-inlineid','_sticker_');return null!=SendButton?($(SendButton).trigger('mousedown'),SendButton):null}function GetElementByTagAttributeAttributeFromDocument(attribute,tag,attributeVal,attribute2,attributeVal2){if(IsEmpty(attribute)||IsEmpty(tag)||IsEmpty(attributeVal)||IsEmpty(attribute2)||IsEmpty(attributeVal2))return null;for(var matchingElements=[],allElements=document.getElementsByTagName(tag),i=0;i<allElements.length;i++){var attributeValue=allElements[i].getAttribute(attribute),attributeValue2=allElements[i].getAttribute(attribute2);if(attributeValue==attributeVal&&attributeValue2.includes(attributeVal2)){matchingElements.push(allElements[i]);break}}return matchingElements.length>0?matchingElements[0]:null}function GetElementByTagAndClassFromDocument(tag,classValue){if(IsEmpty(tag)||IsEmpty(classValue))return null;for(var matchingElements=[],allElements=document.getElementsByClassName(classValue),i=0;i<allElements.length;i++){var tagUpper=tag.toUpperCase();if(allElements[i].tagName==tagUpper){matchingElements.push(allElements[i]);break}}return matchingElements.length>0?matchingElements[0]:null}function IsEmpty(str){return!str||0===str.length}SpamMessage('" + ID_Emoji + "');";
        }

        private String GetScriptMessage(String text)
        {
            return @"function Delay(ms){return new Promise((function(resolve,reject){setTimeout(resolve,ms)}))}async function SpamMessage(text){var prefix='{TL_Spamer} - ';if(IsEmpty(text))return console.log(prefix+'Получено пустой текст для отправки. Критическая ошибка'),'Получено пустой текст для отправки. Критическая ошибка';var resultMessageInput=GetMessageInput(),resultClieckSendMessage;return null==resultMessageInput?(console.log(prefix+'Ошибка при поиске окна ввода сообщения. Критическая ошибка'),'Ошибка при поиске окна ввода сообщения. Критическая ошибка'):(resultMessageInput.innerHTML=text,null==ClickOnSendButton()?(console.log(prefix+'Ошибка при нажатии на кнопку отправки сообщения. Критическая ошибка'),'Ошибка при нажатии на кнопку отправки сообщения. Критическая ошибка'):(console.log(prefix+'Сообщение успешно отправлено'),'Сообщение успешно отправлено'))}function GetMessageInput(){var MessageInput=GetElementByTagAndClassFromDocument('div','composer_rich_textarea');return null!=MessageInput?MessageInput:null}function ClickOnSendButton(){var SendButton=GetElementByTagClassTypeFromDocument('button','btn btn-success im_submit','btn btn-md im_submit im_submit_send','submit');return null!=SendButton?($(SendButton).trigger('mousedown'),SendButton):null}function GetElementByTagAndClassFromDocument(tag,classValue){if(IsEmpty(tag)||IsEmpty(classValue))return null;for(var matchingElements=[],allElements=document.getElementsByClassName(classValue),i=0;i<allElements.length;i++){var tagUpper=tag.toUpperCase();if(allElements[i].tagName==tagUpper){matchingElements.push(allElements[i]);break}}return matchingElements.length>0?matchingElements[0]:null}function GetElementByTagClassTypeFromDocument(tag,classValue,classValue2,type){if(IsEmpty(tag)||IsEmpty(classValue)||IsEmpty(classValue2)||IsEmpty(type))return null;for(var matchingElements=[],allElements=document.getElementsByClassName(classValue2),i=0;i<allElements.length;i++){var tagUpper=tag.toUpperCase();if(allElements[i].tagName==tagUpper&&allElements[i].type==type){matchingElements.push(allElements[i]);break}}if(matchingElements.length<=0){allElements=document.getElementsByClassName(classValue);for(var i=0;i<allElements.length;i++){var tagUpper=tag.toUpperCase();if(allElements[i].tagName==tagUpper&&allElements[i].type==type){matchingElements.push(allElements[i]);break}}}return matchingElements.length>0?matchingElements[0]:null}function IsEmpty(str){return!str||0===str.length}SpamMessage('" + text + "');";
        }

        public async Task StartSpamMessage(List<String> UserNames, int Delay, String Message, bool IsStiker)
        {
            LogViewer.WriteLog("Спамер - Проверка параметров -");

            if (String.IsNullOrWhiteSpace(Message))
            {
                IsWork = false;
                logger.Info("Необходимо указать содержимое сообщения");
                throw new Exception("Необходимо указать содержимое сообщения");
            }

            if (Delay < 1000 || Delay > 5000000)
            {
                IsWork = false;
                logger.Info("Указаны некорректные параметры задержки при отправке");
                throw new Exception("Указаны некорректные параметры задержки при отправке");
            }

            if (UserNames != null && UserNames.Count() <= 0)
            {
                IsWork = false;
                logger.Info("Необходимо указать не менее одного пользователя");
                throw new Exception("Необходимо указать не менее одного пользователя");
            }

            if (BrowserViewer.GetCurrentUrl() == "https://web.telegram.org/#/login")
            {
                IsWork = false;
                logger.Info("Необходимо авторизоваться в браузере");
                throw new Exception("Необходимо авторизоваться в браузере");
            }

            StopWork();

            LogViewer.WriteLog("Спамер - В работе -");

            for (int i = 0; i < UserNames.Count; i++)
            {
                StopWork();

                BrowserViewer.browser_form.chromeBrowser.Load($"https://web.telegram.org/#/im?p={UserNames[i]}");

                await Task.Delay(2000);

                int counter = 0;

                while (true)
                {
                    StopWork();

                    if (BrowserViewer.browser_form.chromeBrowser.IsLoading)
                    {
                        if (counter == 10)
                        {
                            logger.Warn("В течении 10 секунд не был получен ответ об удачной загрузке страницы в браузере");
                            throw new Exception("В течении 10 секунд не был получен ответ об удачной загрузке страницы в браузере");
                        }

                        counter++;
                        await Task.Delay(1000);
                        continue;
                    }

                    break;
                }

                StopWork();

                String script = null;

                if (IsStiker)
                {
                    script = GetScriptSticker(Message);
                }
                else
                {
                    script = GetScriptMessage(Message);
                }

                if (script!= null && BrowserViewer.browser_form.chromeBrowser.CanExecuteJavascriptInMainFrame && !String.IsNullOrWhiteSpace(script))
                {
                    JavascriptResponse javascriptResponse = await BrowserViewer.browser_form.chromeBrowser.EvaluateScriptAsPromiseAsync(script);

                    if (javascriptResponse.Success)
                    {
                        LogViewer.WriteLog($"Инъекция скрипта - ({i + 1}) '{UserNames[i]}' - Успешно -");
                    }
                    else
                    {
                        LogViewer.WriteLog($"Инъекция скрипта - ({i + 1}) '{UserNames[i]}' - Неудачно -");
                    }
                }

                await Task.Delay(GetDelay(Delay, UserNames[i].Length));

                StopWork();
            }
        }

        private int GetDelay(int Delay, int countSymbol)
        {
            int input = 300;

            int TempDelay = Delay - (input);

            if (TempDelay < 0)
            {
                Delay += Math.Abs(TempDelay);
            }

            return Delay;
        }

        public static void SetLogConsole(String MessageLog)
        {
            try
            {
                (String, Boolean) message = new ConsoleFilter().GetResult(MessageLog);

                if (message.Item1 != null)
                {
                    LogViewer.WriteLog(message.Item1);

                    if (message.Item2)
                    {
                        Spamer.IsWork = false;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
            }
        }
    }
}
