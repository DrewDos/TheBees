using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using TheBees.Forms;

namespace TheBees
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

            BaseDataHandler.Initialize();

            Application.Run(new MainForm());
        }
    }
}
