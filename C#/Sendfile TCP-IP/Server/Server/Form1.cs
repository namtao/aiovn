using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Server.path = "C:/Users/PC/Desktop/"; //mặc định nhận file tại desktop
        }
        public static string path;
        public static string MessageCurrent = "Stopped";
        private void Form1_Load(object sender, EventArgs e)
        {
            if(Server .path .Length >0)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Not Receive File");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Server.MessageCurrent + Environment.NewLine + Server.path;
        }
        Server server = new Server();

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            server.StartServer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Server.path.Length > 0)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Not Receive File");
            }
        }
    }
}
