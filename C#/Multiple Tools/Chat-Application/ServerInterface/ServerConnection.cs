using System;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using System.Net;
using ServerBI;
using System.Net.Sockets;

namespace ServerInterface
{
    public partial class ServerConnection : Form
    {
        public ServerConnection(ServerData sdat)
        {
            Sdata = sdat;
            InitializeComponent();
        }

        ServerData Sdata;
        IPAddress ServerIP;
        string adress;

        private void CreateServerButton_Click(object sender, EventArgs e)
        {
            // check ip
            this.IPmaskedTextBox.ValidatingType = typeof(IPAddress);
            char[] delimit = { ' ' };
            string[] str = IPmaskedTextBox.Text.Split();
            string separator = "";
            adress = IPmaskedTextBox.Text;
            bool b = IPAddress.TryParse(adress, out ServerIP);

            if (b)
            {
                Sdata.IPadress = adress;
                ServerBools.IPisVAlid = true;
            }

            else
            {
                MessageBox.Show("IP không khả dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // check port
            int portnum;
            bool p = int.TryParse(portTextBox.Text, out portnum);

            if (p)
            {
                if (portnum.PortisValid())
                {
                    Sdata.Portnumber = portnum;
                    ServerBools.PortValid = true;
                }

                else
                {
                    MessageBox.Show("IP trong khoảng 10000 đến 65535", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("IP không khả dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Tạo phòng
            if (ServerBools.ServerisValid)

                Close();

            else
            {
                MessageBox.Show("Không để thông tin trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ServerConnection_Load(object sender, EventArgs e)
        {
            ServerLogic.ConnecionWhithWrongIPorPort += ServerInterfaceClass.AtemmttoconnectWhithWrongIPandPort_Handler;
            IPmaskedTextBox.Text = GetLocalIPAddress();
            portTextBox.Text = "12121";
        }

        private void ServerConnection_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
