using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            if(fd.ShowDialog() == System .Windows .Forms .DialogResult .OK)
            {
                Client.SendFile(fd.FileName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Client.MessageCurrent;
        }
    }
}
