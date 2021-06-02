using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO ;
namespace Server
{
    class Server
    {
        IPEndPoint end;
        Socket sock;
        public Server()
        {
            end = new IPEndPoint(IPAddress.Any, 2014);
            sock = new Socket (AddressFamily .InterNetwork , SocketType.Stream , ProtocolType .IP);
            sock.Bind(end);
        }
        public static string path;
        public static string MessageCurrent = "Stopped";
        
        public void StartServer()
        {
            try
            {
                MessageCurrent = "Starting...";
                sock.Listen(100);
                MessageCurrent = "It Works and looks for files";
                Socket clientSock = sock.Accept();
                byte[] clientData = new byte[1024 * 5000];
                int receiveByteLen = clientSock.Receive(clientData);
                MessageCurrent = "Receiving file ....";
                int fNameLen = BitConverter.ToInt32(clientData, 0);
                string fName = Encoding.ASCII.GetString(clientData, 4, fNameLen);
                BinaryWriter write = new BinaryWriter (File.Open (path + "/" + fName ,  FileMode.Append ));
                write .Write (clientData , 4+fNameLen , receiveByteLen -4 -fNameLen );
                MessageCurrent = "Saving file....";
                write .Close ();
                clientSock .Close ();
                MessageCurrent = "The file was Received";

            }
            catch{
                MessageCurrent ="Error! File not received";
            }

        }
    }
}
