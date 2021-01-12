using CefSharp;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TELEGRAM_INVITER.Exceptions;

namespace TELEGRAM_INVITER.Services
{
    public class Inviter
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

        private String GetScript(String nameUser)
        {
            return @"function Delay(ms){return new Promise((function(resolve,reject){setTimeout(resolve,ms)}))}async function InviteUser(nameUser){var prefix='{TL_Inviter} - ';if(IsEmpty(nameUser))return console.log(prefix+'Получено пустое имя пользователя. Критическая ошибка'),'Получено пустое имя пользователя. Критическая ошибка';var resultChannelDiv=null,resultButtonInvite=null,resultChannelButton=null,resultContactslDiv=GetContactslDiv();if(null!=resultContactslDiv)return await SetUser(nameUser,resultContactslDiv,prefix);if(null!=(resultChannelDiv=GetChannelDiv()))return null==(resultButtonInvite=ClickOnButtonInvite())?(console.log(prefix+'Ошибка при поиске метода приглашения пользователя в группу. Проверьте наличие прав на добавление в канал'),'Ошибка при поиске метода приглашения пользователя в группу. Проверьте наличие прав на добавление в канал'):(await Delay(300),null==(resultContactslDiv=GetContactslDiv())?(console.log(prefix+'Ошибка при поиске контейнера контактов. Критическая ошибка'),'Ошибка при поиске контейнера контактов. Критическая ошибка'):await SetUser(nameUser,resultContactslDiv,prefix));for(var count=0,resultChannelButton=null;resultChannelButton=ClickOnChannelButton(),5!=count&&null==resultChannelButton;)null==resultChannelButton&&(count+=1,await Delay(1e3));return null==resultChannelButton?(console.log(prefix+'Ошибка при поиске метода взаимодействия с функциями канала. Критическая ошибка'),'Ошибка при поиске метода взаимодействия с функциями канала. Критическая ошибка'):(await Delay(300),null==(resultChannelDiv=GetChannelDiv())?(console.log(prefix+'Ошибка при поиске контейнера канала. Критическая ошибка'),'Ошибка при поиске контейнера канала. Критическая ошибка'):null==(resultButtonInvite=ClickOnButtonInvite())?(console.log(prefix+'Ошибка при поиске метода приглашения пользователя в группу. Проверьте наличие прав на добавление в канал'),'Ошибка при поиске метода приглашения пользователя в группу. Проверьте наличие прав на добавление в канал'):(await Delay(300),null==(resultContactslDiv=GetContactslDiv())?(console.log(prefix+'Ошибка при поиске контейнера контактов. Критическая ошибка'),'Ошибка при поиске контейнера контактов. Критическая ошибка'):await SetUser(nameUser,resultContactslDiv,prefix)))}async function SetUser(nameUser,resultContactslDiv,prefix){var resultSearchInput=GetSearchInput(resultContactslDiv),resultClickSelectedUser;if(null==resultSearchInput)return console.log(prefix+'Ошибка при поиске области поиска пользователя. Критическая ошибка'),'Ошибка при поиске области поиска пользователя. Критическая ошибка';resultSearchInput.value='',resultSearchInput.dispatchEvent(new Event('change'));for(var i=0;i<nameUser.length;i++)resultSearchInput.value=resultSearchInput.value+nameUser[i],resultSearchInput.dispatchEvent(new Event('change')),await Delay(250);for(var count=0,resultButtonClickUser=null;resultButtonClickUser=ClickOnButtonUser(resultContactslDiv,nameUser),5!=count&&null==resultButtonClickUser;)null==resultButtonClickUser&&(count+=1,await Delay(1e3));return null==resultButtonClickUser?(resultSearchInput.value='',resultSearchInput.dispatchEvent(new Event('change')),console.log(prefix+'Пользователь '+nameUser+' не найден'),'Пользователь '+nameUser+' не найден'):(await Delay(300),null==ClickButtonSelectedUser(resultContactslDiv)?(console.log(prefix+'Кнопка подтверждения приглашения пользователя не найдена. Критическая ошибка'),'Кнопка подтверждения приглашения пользователя не найдена. Критическая ошибка'):(console.log(prefix+'Запрос добавления пользователя '+nameUser+' в канал успешно отправлен'),'Запрос добавления пользователя '+nameUser+' в канал успешно отправлен'))}function ClickOnButtonInvite(){var buttonInvite=GetElementByTagAndTwoAttributeFromDocument('ng-click','a','inviteToChannel()','inviteToGroup()');return null!=buttonInvite?(buttonInvite.click(),buttonInvite):null}function GetChannelDiv(){var channelDiv=GetElementByTagAndClassFromDocument('div','chat_modal_wrap md_modal_wrap');return null!=channelDiv?channelDiv:null}function GetContactslDiv(){var сontactslDiv=GetElementByTagAndClassFromDocument('div','contacts_modal_wrap md_modal_wrap');return null!=сontactslDiv?сontactslDiv:null}function ClickOnButtonUser(element,userName){var buttonUser=ClickOnUserContainerFromElement('ng-click','a','contacts_modal_contact','contactSelect(contact.userID)',element,'span',userName);return null!=buttonUser?(buttonUser.click(),buttonUser):null}function GetSearchInput(element){var сontactslDiv=GetElementByTagAndAttributeFromElement('ng-model','input','search.query','search',element);return null!=сontactslDiv?сontactslDiv:null}function ClickButtonSelectedUser(element){var selectButton=GetElementByTagAndAttributeFromElement('ng-click','button','submitSelected()','submit',element);return null!=selectButton?(selectButton.click(),selectButton):null}function ClickOnChannelButton(){var buttonChannel=GetElementByTagAndAttributeFromDocument('ng-click','a','showPeerInfo()');return null!=buttonChannel?(buttonChannel.click(),buttonChannel):null}function GetElementByTagAndAttributeFromDocument(attribute,tag,attributeVal){if(IsEmpty(attribute))return null;if(IsEmpty(tag))return null;if(IsEmpty(attributeVal))return null;for(var matchingElements=[],allElements=document.getElementsByTagName(tag),i=0;i<allElements.length;i++){var attributeValue;if(allElements[i].getAttribute(attribute)==attributeVal){matchingElements.push(allElements[i]);break}}return matchingElements.length>0?matchingElements[0]:null}function GetElementByTagAndTwoAttributeFromDocument(attribute,tag,attributeVal,attributeVal2){if(IsEmpty(attribute))return null;if(IsEmpty(tag))return null;if(IsEmpty(attributeVal))return null;if(IsEmpty(attributeVal2))return null;for(var matchingElements=[],allElements=document.getElementsByTagName(tag),i=0;i<allElements.length;i++){var attributeValue=allElements[i].getAttribute(attribute);if(attributeValue==attributeVal||attributeValue==attributeVal2){matchingElements.push(allElements[i]);break}}return matchingElements.length>0?matchingElements[0]:null}function GetElementByTagAndClassFromDocument(tag,classValue){if(IsEmpty(tag))return null;if(IsEmpty(classValue))return null;for(var matchingElements=[],allElements=document.getElementsByClassName(classValue),i=0;i<allElements.length;i++){var tagUpper=tag.toUpperCase();if(allElements[i].tagName==tagUpper){matchingElements.push(allElements[i]);break}}return matchingElements.length>0?matchingElements[0]:null}function ClickOnUserContainerFromElement(attribute,tag,classValue,attributeVal,element,tag2,username){if(IsEmpty(tag))return null;if(IsEmpty(classValue))return null;if(IsEmpty(attribute))return null;if(IsEmpty(attributeVal))return null;if(null==element)return null;if(IsEmpty(tag2))return null;if(IsEmpty(username))return null;for(var matchingElements=[],allElements=element.getElementsByTagName(tag),i=0;i<allElements.length;i++){if(allElements[i].className==classValue&&allElements[i].getAttribute(attribute)==attributeVal)for(var allElementsSpan=allElements[i].getElementsByTagName(tag2),j=0;j<allElementsSpan.length;j++)if(allElementsSpan[j].innerText==username){matchingElements.push(allElements[i]);break}if(matchingElements.length>0)break}return matchingElements.length>0?matchingElements[0]:null}function GetElementByTagAndAttributeFromElement(attribute,tag,attributeVal,type,element){if(IsEmpty(attribute))return null;if(IsEmpty(tag))return null;if(IsEmpty(attributeVal))return null;if(IsEmpty(type))return null;if(null==element)return null;for(var matchingElements=[],allElements=element.getElementsByTagName(tag),i=0;i<allElements.length;i++){var attributeValue;if(allElements[i].getAttribute(attribute)==attributeVal&&allElements[i].type==type){matchingElements.push(allElements[i]);break}}return matchingElements.length>0?matchingElements[0]:null}function IsEmpty(str){return!str||0===str.length}InviteUser('" + nameUser + "');";
        }

        public async Task StartInvite(List<String> Groups, List<String> UserNames, int Delay, Boolean useGroupStop = false, int Countgroup = 5, int GroupDelay = 20000)
        {
            LogViewer.WriteLog("Инвайтер - Проверка параметров -");

            if (Delay < 1000 || Delay > 5000000)
            {
                IsWork = false;
                logger.Info("Указаны некорректные параметры задержки при отправке");
                throw new Exception("Указаны некорректные параметры задержки при отправке");
            }

            if (Groups != null && Groups.Count() <= 0)
            {
                IsWork = false;
                logger.Info("Необходимо указать не менее одной группы");
                throw new Exception("Необходимо указать не менее одной группы");
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

            LogViewer.WriteLog("Инвайтер - В работе -");

            for (int g = 0; g < Groups.Count; g++)
            {
                BrowserViewer.browser_form.chromeBrowser.Load($"https://web.telegram.org/#/im?p={Groups[g]}");

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

                for (int i = 0; i < UserNames.Count; i++)
                {
                    String script = GetScript(UserNames[i]);

                    if (BrowserViewer.browser_form.chromeBrowser.CanExecuteJavascriptInMainFrame && !String.IsNullOrWhiteSpace(script))
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

                    if(useGroupStop)
                    {
                        if((i + 1) % Countgroup == 0)
                        {
                            LogViewer.WriteLog($"Инвайтер - Обработано пользователей {i + 1} -");
                            LogViewer.WriteLog($"Инвайтер - Ожидание {GroupDelay} мс -");
                            await Task.Delay(GroupDelay);
                        }
                    }

                    await Task.Delay(GetDelay(Delay, UserNames[i].Length));
                    StopWork();
                }
            }
        }

        private int GetDelay(int Delay, int countSymbol)
        {
            int clickChannelButton = 300;
            int clickInviteButton = 300;
            int searchInputChar = countSymbol * 250;
            int searchWorking = 5 * 1000;
            int waitButtonChannel = 5 * 1000;
            int clickSearchUser = 300;

            int TempDelay = Delay - (clickChannelButton + clickInviteButton + searchInputChar + searchWorking + clickSearchUser + waitButtonChannel);

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
                        Inviter.IsWork = false;
                    }
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
            }
        }
    }
}
