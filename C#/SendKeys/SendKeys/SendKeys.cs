using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SendKeys
{
    class SendKeysSupported
    {
        public SendKeysSupported()
        {

        }

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Send a series of key presses to the Calculator application.
        /// <summary>
        /// Sends the wait.
        /// </summary>
        public void SendWait(string windowtitle, string msg)
        {
            if (!string.IsNullOrWhiteSpace(windowtitle))
            {
                // Get a handle to the another application. The window class
                // and window name were obtained using the Spy++ tool.
                IntPtr windowHandler = FindWindow(null, windowtitle);

                // Verify that app/form/ưindow is a running process.
                if (windowHandler == IntPtr.Zero)
                {
                    System.Windows.MessageBox.Show("Could not found");
                    return;
                }

                // Make another application the foreground application and send it 
                // a set of calculations.
                SetForegroundWindow(windowHandler);
                System.Windows.Forms.SendKeys.SendWait(msg);
            }
        }
    }
}
