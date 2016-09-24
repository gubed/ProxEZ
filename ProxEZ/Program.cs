using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProxEZ.Forms;

namespace ProxEZ
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new frmMain());
        }
    }
}
