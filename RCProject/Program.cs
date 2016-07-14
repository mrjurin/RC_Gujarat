using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using System.IO;

namespace RCProject
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
            //bool OriginalFileExists = File.Exists(@"C:\RC_SQL_DB.ini");
            bool OriginalFileExists = File.Exists(@"D:\RC_SQL_DB.ini");
            if (!OriginalFileExists)
            {
                Application.Run(new CreateINI());

            }
            else
                Application.Run(new Login());
        }
    }
}
