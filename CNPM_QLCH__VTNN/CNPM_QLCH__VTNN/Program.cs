using CNPM_QLCH__VTNN.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_QLCH__VTNN
{
    static class Program
    {
        public static string d = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Views.Main f = new Views.Main();
            f.WindowState = FormWindowState.Maximized;
            Application.Run(f);
        }
    }
}
