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
    public partial class Console : Form
    {
        public Console()
        {
            InitializeComponent();
        }

        private void Console_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConsoleViewer.IsClose)
            {
                e.Cancel = true;
                ConsoleViewer.Hide();
                return;
            }
        }

        private void Console_Load(object sender, EventArgs e)
        {

        }
    }
}
