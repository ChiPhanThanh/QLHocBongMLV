using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHocBongMLV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            //Application.Run(new ResetPassWord());
            //Application.Run(new Sign_in());
            //Application.Run(new panelMain());
            //Application.Run(new QLSinhVien());
            //Application.Run(new QLHocSinh());
             Application.Run(new ProgressBarInterface());
           //Application.Run(new panelMain());
            //Application.Run(new QLSinhVien());
            //Application.Run(new QLHocSinh());

        }
    }
}
