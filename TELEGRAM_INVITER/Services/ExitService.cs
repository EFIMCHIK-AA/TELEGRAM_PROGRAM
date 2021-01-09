using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TELEGRAM_INVITER.Services
{
    public class ExitService
    {
        public void ApplicationExit()
        {
            if(MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Разрущить браузер
                Application.Exit();
            }
        }
    }
}
