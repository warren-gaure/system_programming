using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace ExternalConsole.Model
{
    internal class Communication
    {
        public static ObservableCollection<Save> Start(ObservableCollection<Save> saves, string Ip = "127.0.0.1", int Port = 11231)
        {
            using TcpClient client = new TcpClient(Ip, Port);
            NetworkStream stream = client.GetStream();
            int i;
            String data = null;
            Byte[] bytes = new Byte[2048];
            data = null;
            stream.Write(Encoding.ASCII.GetBytes("GetSaves"), 0, 8);
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                var arraySaves = JsonSerializer.Deserialize<Save[]>(data);
                if (arraySaves != null) 
                {
                    foreach(var save in arraySaves)
                    {
                        if (saves.Where(e => e.Name == save.Name).Count() > 0)
                        {
                            if(saves.Where(e => e.Name == save.Name).First().Percent != save.Percent) saves.Where(e => e.Name == save.Name).First().Percent = save.Percent;
                            if (saves.Where(e => e.Name == save.Name).First().State != save.State) saves.Where(e => e.Name == save.Name).First().State = save.State;
                        }
                        else
                        {
                            saves.Add(save);
                        }
                    }
                }
                //Debug.WriteLine("Client Received: " + data);
            }
            stream.Close();
            client.Close();
            return saves;
        }

        public static void SetSave(string[] Names, int State, string Ip = "127.0.0.1", int Port = 11231)
        {
            using TcpClient client = new TcpClient(Ip, Port);
            NetworkStream stream = client.GetStream();
            int i;
            String data = null;
            Byte[] bytes = new Byte[256];
            var message = "SetSaves(";
            foreach(var Name in Names)
            {
                message += Name + ",";
            }
            message = message.TrimEnd(',');
            message += ")[" + State.ToString() + "]";
            var mbytes = Encoding.ASCII.GetBytes(message);
            stream.Write(mbytes, 0, mbytes.Length);
        }


    }
}
