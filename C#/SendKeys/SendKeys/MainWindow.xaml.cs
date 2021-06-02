using System.Windows;
using System.Diagnostics;

namespace SendKeys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SendKeysSupported sendkeys = new SendKeysSupported();
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
            this.txtmsg.Text = "{TAB}|Phạm Tuân|{TAB}|Q12 - HCM|{TAB}|12|{TAB}|23|{TAB}|56|{TAB}|78|{TAB}|99";
            Process.Start("SendKeysTest.exe");
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sendkeys.SendWait(this.txtwindowtitle.Text, @"%{F4}");
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string[] separator = { "|" }; // separator
            var msgList = this.txtmsg.Text.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in msgList)
            {
                sendkeys.SendWait(this.txtwindowtitle.Text, item);
            }
        }
    }
}
