using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ListView_TreeView_Directory_View
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
            Application.Run(new Tree());
        }
    }
}