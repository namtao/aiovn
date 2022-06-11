using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerBI
{
    class FTServerCode
    {
        IPEndPoint ipEnd;
        Socket sock;
        public FTServerCode()
        {
            ipEnd = new IPEndPoint(IPAddress.Any, 5656);
            //Make IP end point to accept any IP address with port no 5656.
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            //Here creating new socket object with protocol type and transfer data type
            sock.Bind(ipEnd);
            //Bind end point with newly created socket.
        }
        public static string receivedPath;
        public static string curMsg = "Stopped";
        public void StartServer()
        {
            try
            {
                curMsg = "Starting...";
                sock.Listen(100);
                /* That socket object can handle maximum 100 client connection at a time & 
                waiting for new client connection /
                curMsg = "Running and waiting to receive file.";*/
                Socket clientSock = sock.Accept();
                /* When request comes from client that accept it and return 
                new socket object for handle that client. */
                byte[] clientData = new byte[1024 * 5000];
                int receivedBytesLen = clientSock.Receive(clientData);
                curMsg = "Receiving data...";
                int fileNameLen = BitConverter.ToInt32(clientData, 0);
                /* I've sent byte array data from client in that format like 
                [file name length in byte][file name] [file data], so need to know 
                first how long the file name is. */
                string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);
                /* Read file name */
                BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + "/" + fileName, FileMode.Append)); ;
                /* Make a Binary stream writer to saving the receiving data from client. /
                bWrite.Write(clientData, 4 + fileNameLen, 
            receivedBytesLen - 4 - fileNameLen);
                /* Read remain data (which is file content) and 
                save it by using binary writer. */
                curMsg = "Saving file...";
                bWrite.Close();
                clientSock.Close();
                /* Close binary writer and client socket */
                curMsg = "Received & Saved file; Server Stopped.";
            }
            catch (Exception ex)
            {
                curMsg = "File Receiving error.";
            }
        }
    }
}
