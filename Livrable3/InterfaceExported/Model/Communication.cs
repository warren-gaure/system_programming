using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Diagnostics;

namespace InterfaceExported.Model
{
    internal class Communication
    {

        public static void Start(string Ip = "127.0.0.1", int Port = 11231)
        {
            using TcpClient client = new TcpClient(Ip, Port);
            NetworkStream stream = client.GetStream();
            int i;
            String data = null;
            Byte[] bytes = new Byte[256];
            while(true)
            {
                data = null;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    Debug.WriteLine("Client Received: " + data);
                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                    Debug.WriteLine("Client Send: " + data);
                }
                Thread.Sleep(500);
            }
        }

    }
}
