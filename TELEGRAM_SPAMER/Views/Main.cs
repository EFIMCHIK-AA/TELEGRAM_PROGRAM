using NLog;
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
    public partial class Main : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Main()
        {
            InitializeComponent();
            InitializeServices();
        }

        private void InitializeServices()
        {
            try
            {
                ConsoleViewer.console_form = new Console();
                ConsoleLogViewer.Textbox_logger_control = ConsoleViewer.console_form.Log_TB;

                LogViewer.Textbox_logger_control = Log_TB;
                BrowserViewer.browser_form = new Browser();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
            }
        }

        private void FillInviteList(DataGridView dataGridView, List<String> dataList)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                Invoke(new Action(() =>
                {
                    dataGridView.Rows.Add(dataList[i]);
                }));
            }
        }

        private async void ImportUser_B_Click(object sender, EventArgs e)
        {
            try
            {
                LogViewer.WriteLog("Импорт базы пользователей - Старт операции -");

                ImportUser_B.Enabled = false;
                ImportUser_B.Text = "Загрузка...";

                Start_B.Enabled = false;

                List<string> userNames = await new ImportDataService().ImportData(true);
                await Task.Run(() => FillInviteList(DataUsers_DGV, userNames));

                ImportUser_B.Text = "Импортировать";
                ImportUser_B.Enabled = true;

                Start_B.Enabled = true;

                LogViewer.WriteLog("Импорт базы пользователей - Завершено успешно -");
            }
            catch (Exception ex)
            {
                ImportUser_B.Text = "Импортировать";
                ImportUser_B.Enabled = true;
                Start_B.Enabled = true;
                logger.Error(ex.Message, ex.StackTrace);
                LogViewer.WriteLog("Импорт базы пользователей - Завершено аварийно -");
            }
        }

        private void Exit_B_Click(object sender, EventArgs e)
        {
            try
            {
                LogViewer.WriteLog("Выход из приложения - Старт операции -");

                new ExitService().ApplicationExit();
                
                LogViewer.WriteLog("Выход из приложения - Завершено успешно -");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                LogViewer.WriteLog("Выход из приложения - Завершено аварийно -");
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MessageSettingsService settingsService = new MessageSettingsService();

            MessageText_TB.Text = settingsService.MeesageString;
            IDEmoji_TB.Text = settingsService.IDEmoji;
            ID_Sticker_TB.Text = settingsService.IDSticker;
            UseSticker_CB.Checked = settingsService.UseSticker;
        }


        private void Browser_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BrowserViewer.IsShow)
                {
                    LogViewer.WriteLog("Браузер - Отобразить -");
                    BrowserViewer.Show();
                }
                else
                {
                    LogViewer.WriteLog("Браузер - Скрыть -");
                    BrowserViewer.Hide();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);
                LogViewer.WriteLog("Ошибка при попытке взаимодействия с окном браузера");
            }
        }



        private async void Start_B_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if(Inviter.IsWork)
            //    {
            //        LogViewer.WriteLog("Инвайтер - Остановка работы -");
            //        Start_B.Text = "Остановка...";
            //        Start_B.Enabled = false;
            //        Inviter.IsWork = false;
            //        return;
            //    }

            //    LogViewer.Reset();

            //    Inviter.IsWork = true;
            //    Start_B.Text = "Остановить";

            //    LogViewer.WriteLog("Инвайтер - Запуск -");
            //    StateControls(false);

            //    int Delay = AppManager.Settings.Time;

            //    List<String> UsersNames = new List<string>();
            //    for(int i = 0; i < DataUsers_DGV.Rows.Count; i++)
            //    {
            //        if(DataUsers_DGV["UserNames", i].Value != null)
            //        {
            //            String value = DataUsers_DGV["UserNames", i].Value.ToString().Trim();

            //            if (!String.IsNullOrWhiteSpace(value))
            //            {
            //                UsersNames.Add(value);
            //            }
            //        }         
            //    }

            //    List<String> Groups = new List<string>();
            //    for (int i = 0; i < DataGroups_DGV.Rows.Count; i++)
            //    {
            //        if (DataGroups_DGV["NameGroup", i].Value != null)
            //        {
            //            String value = DataGroups_DGV["NameGroup", i].Value.ToString().Trim();

            //            if (!String.IsNullOrWhiteSpace(value))
            //            {
            //                Groups.Add(value);
            //            }
            //        }
            //    }

            //    await new Inviter().StartInvite(Groups, UsersNames, Delay, AppManager.Settings.UseGroupWait, AppManager.Settings.CountGroup, AppManager.Settings.TimeGroup);

            //    StateControls(true);
            //    Start_B.Text = "Начать";
            //    Start_B.Enabled = true;
            //    LogViewer.WriteLog("Инвайтер - Завершено успешно -");
            //}
            //catch (StopWorkException ex)
            //{
            //    StateControls(true);
            //    Start_B.Text = "Начать";
            //    Start_B.Enabled = true;

            //    logger.Error(ex.Message, ex.StackTrace);

            //    LogViewer.WriteLog(ex.Message);
            //    LogViewer.WriteLog("Инвайтер - Завершено -");
            //}
            //catch (Exception ex)
            //{
            //    StateControls(true);
            //    Start_B.Text = "Начать";
            //    Start_B.Enabled = true;

            //    logger.Error(ex.Message, ex.StackTrace);

            //    LogViewer.WriteLog(ex.Message);
            //    LogViewer.WriteLog("Инвайтер - Завершено -");
            //}
        }

        private async void Main_Shown(object sender, EventArgs e)
        {
            BrowserViewer.browser_form.chromeBrowser.Enabled = false;
            ConsoleViewer.console_form.TopMost = true;
            ConsoleViewer.Show();
            BrowserViewer.Show();

            await Task.Delay(2000);

            BrowserViewer.browser_form.chromeBrowser.Enabled = true;
            ConsoleViewer.console_form.TopMost = false;
            ConsoleViewer.Hide();
            BrowserViewer.Hide();
        }

        private void Console_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ConsoleViewer.IsShow)
                {
                    LogViewer.WriteLog("Консоль - Отобразить -");
                    ConsoleViewer.Show();
                }
                else
                {
                    LogViewer.WriteLog("Консоль - Скрыть -");
                    ConsoleViewer.Hide();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);

                LogViewer.WriteLog("Ошибка при попытке взаимодействия с окном браузера");
            }
        }

        private void Settings_B_Click(object sender, EventArgs e)
        {
            try
            {
                LogViewer.WriteLog("Настройки - Изменение параметров -");

                Settings dialog = new Settings();

                dialog.Time_NUD.Value = AppManager.Settings.Time;

                dialog.Owner = this;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SettingsService settingsService = new SettingsService();

                    TELEGRAM_SPAMER.Models.Settings settings = new TELEGRAM_SPAMER.Models.Settings
                    {
                        BrowserReload = false,
                        Time = Convert.ToInt32(dialog.Time_NUD.Value)
                    };

                    settingsService.Save(settings);
                    AppManager.Settings = settings;
                }

                LogViewer.WriteLog("Настройки - Изменение параметров завершено -");
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);

                LogViewer.WriteLog("Настройки - Изменение параметров завершено -");
            }
        }

        private void SaveMessageSettings_B_Click(object sender, EventArgs e)
        {
            try
            {
                LogViewer.WriteLog("Настройки сообщения - Изменение параметров -");

                MessageSettingsService settingsService = new MessageSettingsService();

                Models.MessageSettings settings = new Models.MessageSettings
                {
                    MeesageString = MessageText_TB.Text.Trim(),
                    UseSticker = UseSticker_CB.Checked,
                    IDEmoji = IDEmoji_TB.Text.Trim(),
                    IDSticker = ID_Sticker_TB.Text.Trim()
                };

                settingsService.Save(settings);
                LogViewer.WriteLog("Настройки сообщения - Изменение параметров завершено -");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex.StackTrace);

                LogViewer.WriteLog("Настройки сообщения - Изменение параметров завершено -");
            }
        }

        private void StateControls(Boolean state)
        {
            Settings_B.Enabled = state;
            SaveMessageSettings_B.Enabled = state;
            ImportUser_B.Enabled = state;
            DataUsers_DGV.ReadOnly = !state;
            DataUsers_DGV.AllowUserToDeleteRows = state;
            MessageText_TB.ReadOnly = !state;
            IDEmoji_TB.ReadOnly = !state;
            ID_Sticker_TB.ReadOnly = !state;
            UseSticker_CB.Enabled = state;
            BrowserViewer.browser_form.chromeBrowser.Enabled = state;
        }
    }
}
