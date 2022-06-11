using System;
using System.Drawing;

namespace CommonTypes
{

    [Serializable]
    public enum NetworkAction
    { IpandPortValidaton = 1, Connection = 2, Sendmessage = 3, SendPrivateMessage = 22, ReceiveMesg = 4, RequestforListofUsers = 5, ConectionREsponse = 6, UserDisconnection = 7, SeverDisconnection = 8, None = 99 }



    [Serializable]
     public abstract  class CommonVariables


    {

        public DateTime Time
        { get; set; }

        public Color color
        { get; set; }

       

        public string IPadress
        { get; set; }

        public int Portnumber
        { get; set; }

        public static ServerData CommonSd
        { get; set; }


      
    }
}
