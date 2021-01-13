using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TELEGRAM_SPAMER.Services
{
    public static class ConsoleViewer
    {
        public static TELEGRAM_INVITER.Views.Console console_form;

        public static Boolean IsClose = false;
        public static Boolean IsShow = false;

        public static void Show()
        {
            if (console_form != null)
            {
                console_form.Show();

                if (console_form.WindowState == FormWindowState.Minimized)
                {
                    console_form.WindowState = FormWindowState.Normal;
                }

                IsShow = true;
            }
        }

        public static void Hide()
        {
            if (console_form != null)
            {
                console_form.Hide();
                IsShow = false;
            }
        }

        public static void Close()
        {
            if (console_form != null)
            {
                if (IsClose)
                {
                    console_form.Close();
                    IsShow = false;
                }
            }
        }
    }
}
