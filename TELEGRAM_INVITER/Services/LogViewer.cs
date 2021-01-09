using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TELEGRAM_INVITER.Services
{
    public static class LogViewer
    {
        public static TextBox Textbox_logger_control;

        public static void WriteLog(String message)
        {
            if (Textbox_logger_control != null)
            {
                if(Textbox_logger_control.Lines.Count() > 0)
                {
                    Textbox_logger_control.AppendText(Environment.NewLine);
                }

                Textbox_logger_control.AppendText($"[{DateTime.Now:h:mm:ss tt}] : {message}");
            }
        }

        public static void Reset()
        {
            if (Textbox_logger_control != null)
            {
                Textbox_logger_control.Clear();
            }
        }
    }
}
