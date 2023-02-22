using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace Livrable3.Model
{
    class Communication
    {

    
        public static void Start()
        {
            var server = TcpListener.Create(11231);
            server.Start();
            Byte[] data = null;
            var message = "[Name, Percent, Stat; Name2, Percent, Stat]";
            while (true)
            {
                Debug.WriteLine("Waiting connection");
                using (var client = server.AcceptTcpClient())
                {
                    Debug.WriteLine("Connected");
                    NetworkStream stream = client.GetStream();
                    while(true)
                    {
                        data = Encoding.ASCII.GetBytes(message.ToString());
                        stream.Write(data, 0, data.Length);
                        Debug.WriteLine("Server Send: " + message);
                        data = new Byte[256];
                        String responseData = String.Empty;
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = Encoding.ASCII.GetString(data, 0, bytes);
                        Debug.WriteLine("Server Received: " + responseData);
                        Thread.Sleep(500);
                    }
                    
                }
            }

        }
    }
}
