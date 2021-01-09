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

                List<string> userNames = await new ImportDataService().ImportData(true);
                await Task.Run(() => FillInviteList(DataUsers_DGV, userNames));

                ImportUser_B.Text = "Импортировать";
                ImportUser_B.Enabled = true;
                LogViewer.WriteLog("Процедура импорта базы пользователей - Завершено успешно -");
            }
            catch (Exception)
            {
                ImportUser_B.Text = "Импортировать";
                ImportUser_B.Enabled = true;
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

                List<string> groupsNames = await new ImportDataService().ImportData();
                await Task.Run(() => FillInviteList(DataGroups_DGV, groupsNames));

                ImportGroup_B.Text = "Импортировать";
                ImportGroup_B.Enabled = true;
                LogViewer.WriteLog("Процедура импорта базы групп - Завершено успешно -");
            }
            catch (Exception)
            {
                ImportGroup_B.Text = "Импортировать";
                ImportGroup_B.Enabled = true;
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
    }
}
