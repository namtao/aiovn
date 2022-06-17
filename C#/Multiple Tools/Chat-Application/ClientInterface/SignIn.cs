using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using CommonTypes;
using ClientBL;

namespace ClientInterface
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();

        }

        IPAddress clientIpAddr;
        internal UserData new_user;
        MessageData mData;
        internal string userNIckname;
        internal string IPasString;
        internal int userPort;
        internal List<UserData> localListofUsers;


        private void ClearAll()
        {
            IPmaskedTextBox.Clear();
            UserNameBox.Clear();
            portTextBox.Clear();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            // check IP
            this.IPmaskedTextBox.ValidatingType = typeof(IPAddress);
            char[] delimit = { ' ' };
            string[] str = IPmaskedTextBox.Text.Split();
            string separator = "";
            IPasString = IPmaskedTextBox.Text;
            bool b = IPAddress.TryParse(IPasString, out clientIpAddr);



            bool portvalid = int.TryParse(portTextBox.Text, out userPort);

            if (!portvalid)
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (!b)
            {
                MessageBox.Show("Thông tin không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (!userPort.PortisValid())
            {
                MessageBox.Show("Cổng trong khoảng 10000 đến 65535", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {

                mData = new MessageData(new UserData(IPasString, userPort), NetworkAction.IpandPortValidaton);
                UserLogic.IPAndPortValidation(mData);



                if (UserLogic.GlobalValidIpandPort)
                {
                    localListofUsers = ClientProps.listofUserfortheUsers;
                    ClientInterfaceProps.IPandPortconfirmed = UserLogic.GlobalValidIpandPort;

                }

                else
                {
                    MessageBox.Show("Thông tin không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            //check name
            if (ClientInterfaceProps.IPandPortconfirmed)
            {
                var listofnames = from n in localListofUsers
                                  where n != null
                                  select (n.Username);


                bool a = listofnames.Contains(UserNameBox.Text);

                if (UserNameBox.Text != "")
                {
                    if (!a)
                    {
                        userNIckname = UserNameBox.Text;
                        ClientInterfaceProps.uNmake = userNIckname;
                        ClientInterfaceProps.NicnameConfirmed = true;
                    }

                    else
                    {
                        MessageBox.Show("Tên đã có!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Tên không khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //kết nối
            if (ClientInterfaceProps.UserIsValid)
            {
                // tên người dùng đăng nhập
                new_user = new UserData(IPasString, userPort, userNIckname);
                MessageData mData = new MessageData(new_user);
                mData.action = NetworkAction.Connection;
                UserLogic.LolacAction = NetworkAction.Connection;
                UserLogic.ConnecttoServer(mData, new_user);
                ClientProps.shutdown = false;
                ClearAll();
                Close();
            }

             else
             {
                MessageBox.Show("Không được để trống thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClientInterfaceProps.ResetBooleans();

             }
        }


        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearAll();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }
    }
}
