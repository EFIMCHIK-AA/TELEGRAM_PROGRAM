using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TELEGRAM_INVITER.Views;

namespace TELEGRAM_INVITER.Services
{
    public static class BrowserViewer
    {
        public static Browser browser_form;

        public static Boolean IsClose = false;
        public static Boolean IsShow = false;

        public static void Show()
        {
            if (browser_form != null)
            {
                browser_form.Show();
                IsShow = true;
            }
        }

        public static void Hide()
        {
            if (browser_form != null)
            {
                browser_form.Hide();
                IsShow = false;

            }
        }

        public static void Close()
        {
            if (browser_form != null)
            {
                if(IsClose)
                {
                    browser_form.Close();
                    IsShow = false;
                }
            }
        }

        public static String GetCurrentUrl()
        {
            if (browser_form != null)
            {
                return browser_form.chromeBrowser.Address;
            }
            else
            {
                throw new Exception("Объект брауезера не найден");
            }
        }
    }
}
