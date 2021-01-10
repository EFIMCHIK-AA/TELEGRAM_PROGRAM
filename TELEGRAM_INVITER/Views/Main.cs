using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TELEGRAM_INVITER.Exceptions;
using TELEGRAM_INVITER.Services;

namespace TELEGRAM_INVITER.Views
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitializeServices();
        }

        private void InitializeServices()
        {
            LogViewer.Textbox_logger_control = Log_TB;
            BrowserViewer.browser_form = new Browser();
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
                LogViewer.WriteLog("Процедура импорта базы пользователей - Старт операции -");

                ImportUser_B.Enabled = false;
                ImportUser_B.Text = "Загрузка...";

                Start_B.Enabled = false;

                List<string> userNames = await new ImportDataService().ImportData(true);
                await Task.Run(() => FillInviteList(DataUsers_DGV, userNames));

                ImportUser_B.Text = "Импортировать";
                ImportUser_B.Enabled = true;

                Start_B.Enabled = true;

                LogViewer.WriteLog("Процедура импорта базы пользователей - Завершено успешно -");
            }
            catch (Exception)
            {
                ImportUser_B.Text = "Импортировать";
                ImportUser_B.Enabled = true;
                Start_B.Enabled = true;
                LogViewer.WriteLog("Процедура импорта базы пользователей - Завершено аварийно -");
            }
        }

        private async void ImportGroup_B_Click(object sender, EventArgs e)
        {
            try
            {
                LogViewer.WriteLog("Процедура импорта базы групп - Старт операции -");

                ImportGroup_B.Enabled = false;
                ImportGroup_B.Text = "Загрузка...";

                Start_B.Enabled = false;

                List<string> groupsNames = await new ImportDataService().ImportData(true);
                await Task.Run(() => FillInviteList(DataGroups_DGV, groupsNames));

                ImportGroup_B.Text = "Импортировать";
                ImportGroup_B.Enabled = true;

                Start_B.Enabled = true;

                LogViewer.WriteLog("Процедура импорта базы групп - Завершено успешно -");
            }
            catch (Exception)
            {
                ImportGroup_B.Text = "Импортировать";
                ImportGroup_B.Enabled = true;

                Start_B.Enabled = true;

                LogViewer.WriteLog("Процедура импорта базы групп - Завершено аварийно -");
            }
        }

        private void Exit_B_Click(object sender, EventArgs e)
        {
            try
            {
                LogViewer.WriteLog("Процедура выхода из приложения - Старт операции -");

                new ExitService().ApplicationExit();
                
                LogViewer.WriteLog("Процедура выхода из приложения - Завершено успешно -");
            }
            catch (Exception)
            {
                LogViewer.WriteLog("Процедура выхода из приложения - Завершено аварийно -");
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }


        private void Browser_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BrowserViewer.IsShow)
                {
                    LogViewer.WriteLog("Отобразить браузер");
                    BrowserViewer.Show();
                }
                else
                {
                    LogViewer.WriteLog("Скрыть браузер");
                    BrowserViewer.Hide();
                }
            }
            catch (Exception)
            {
                LogViewer.WriteLog("Ошибка при попытке взаимодействия с окном браузера");
            }
        }

        private void StateControls(Boolean state)
        {
            ImportGroup_B.Enabled = state;
            ImportUser_B.Enabled = state;
            Time_NUD.Enabled = state;
            DataGroups_DGV.ReadOnly = !state;
            DataGroups_DGV.AllowUserToDeleteRows = state;
            DataUsers_DGV.ReadOnly = !state;
            DataUsers_DGV.AllowUserToDeleteRows = state;
            BrowserViewer.browser_form.chromeBrowser.Enabled = state;
        }

        private async void Start_B_Click(object sender, EventArgs e)
        {
            try
            {
                if(Inviter.IsWork)
                {
                    LogViewer.WriteLog("Инвайтер - Остановка работы -");
                    Start_B.Text = "Остановка...";
                    Start_B.Enabled = false;
                    Inviter.IsWork = false;
                    return;
                }

                LogViewer.Reset();

                Inviter.IsWork = true;
                Start_B.Text = "Остановить";

                LogViewer.WriteLog("Инвайтер - Запуск -");
                StateControls(false);

                int Delay = Convert.ToInt32(Time_NUD.Value);

                List<String> UsersNames = new List<string>();
                for(int i = 0; i < DataUsers_DGV.Rows.Count; i++)
                {
                    if(DataUsers_DGV["UserNames", i].Value != null)
                    {
                        String value = DataUsers_DGV["UserNames", i].Value.ToString().Trim();

                        if (!String.IsNullOrWhiteSpace(value))
                        {
                            UsersNames.Add(value);
                        }
                    }         
                }

                List<String> Groups = new List<string>();
                for (int i = 0; i < DataGroups_DGV.Rows.Count; i++)
                {
                    if (DataGroups_DGV["NameGroup", i].Value != null)
                    {
                        String value = DataGroups_DGV["NameGroup", i].Value.ToString().Trim();

                        if (!String.IsNullOrWhiteSpace(value))
                        {
                            Groups.Add(value);
                        }
                    }
                }

                await new Inviter().StartInvite(Groups, UsersNames, Delay);

                StateControls(true);
                Start_B.Text = "Начать";
                Start_B.Enabled = true;
                LogViewer.WriteLog("Инвайтер - Завершено успешно -");
            }
            catch (StopWorkException ex)
            {
                StateControls(true);
                Start_B.Text = "Начать";
                Start_B.Enabled = true;
                LogViewer.WriteLog(ex.Message);
                LogViewer.WriteLog("Инвайтер - Завершено пользователем -");
            }
            catch (Exception ex)
            {
                StateControls(true);
                Start_B.Text = "Начать";
                Start_B.Enabled = true;
                LogViewer.WriteLog(ex.Message);
                LogViewer.WriteLog("Инвайтер - Завершено аварийно -");
            }
        }

        private async void Main_Shown(object sender, EventArgs e)
        {
            BrowserViewer.browser_form.chromeBrowser.Enabled = false;
            BrowserViewer.Show();

            await Task.Delay(2000);

            BrowserViewer.browser_form.chromeBrowser.Enabled = true;
            BrowserViewer.Hide();

        }
    }
}
