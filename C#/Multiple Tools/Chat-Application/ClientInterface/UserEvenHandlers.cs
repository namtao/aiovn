﻿using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using CommonTypes;

namespace ClientInterface
{
    public partial  class UserInterfaceClass : Form
    {   
        public  void NoServerHandler(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             UserInterfaceDisconnection();
        }


        public  void IncomingMessageHandler(MessageData mData)
        {

            if (ChatrichTextBox.InvokeRequired)
            {
                Action<MessageData> messent = IncomingMessageHandler;
                this.Invoke(messent, new object[] { mData });
            }

            else
            {
                
                if (mData.action == NetworkAction.RequestforListofUsers)

                {
                    var names = from n in mData.listofUsers
                                select n.Username; 


                    for(int i = 0; i < mData.listofUsers.Count; i++)
                    {
                    
                        PrivatecheckedListBox.Items.Add(names.ToArray()[i]);

                    }
                       
                }

                else if (mData.action == NetworkAction.ConectionREsponse)
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\nMáy chủ: ");
                    ChatrichTextBox.SelectionColor = Color.Green;
                    ChatrichTextBox.AppendText("\n\t" + mData.Textmessage);
               

                }

                else if (mData.action == NetworkAction.UserDisconnection)
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\n Máy chủ: ");
                    ChatrichTextBox.SelectionColor = Color.Red;
                    ChatrichTextBox.AppendText("\n\t" + mData.Textmessage);
                    

                }

                else if (mData.action == NetworkAction.SeverDisconnection)
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\n Máy chủ: ");
                    ChatrichTextBox.SelectionColor = Color.Red;
                    ChatrichTextBox.AppendText("\n\t" + mData.Textmessage);
                    ChatrichTextBox.SelectionColor = Color.Black;
                }

                else
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\n" + mData.Userdat.Username + " says: ");
                    ChatrichTextBox.SelectionColor = mData.color;
                    ChatrichTextBox.AppendText("\n\t" + mData.Textmessage);
                    ChatrichTextBox.SelectionColor = Color.Black;
                }
            }


        }

    }
}