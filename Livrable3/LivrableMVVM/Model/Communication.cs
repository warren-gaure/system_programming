using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;

namespace Livrable3.Model
{
    class Communication
    {


        public static void Start()
        {
            var server = TcpListener.Create(11231);
            server.Start();
            string data = null;
            Byte[] bytes = new Byte[256];
            while (true)
            {
                //Debug.WriteLine("Waiting connection");
                using (var client = server.AcceptTcpClient())
                {
                    //Debug.WriteLine("Connected");
                    NetworkStream stream = client.GetStream();
                    int i;
                    data = null;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.ASCII.GetString(bytes, 0, i);
                        if(data=="GetSaves")
                        {
                            var message = GetSaves();
                            var Mbytes = Encoding.ASCII.GetBytes(message);
                            stream.Write(Mbytes, 0, Mbytes.Length);
                            stream.Close();
                            client.Close();
                            break;
                        }
                        else if(data.StartsWith("SetSavesState")) // SetSavesState(Name1,Name2)[0]
                        {
                            var names = data.Substring(data.IndexOf('('), data.Length - 1 - data.IndexOf('(') - 4).Split(',');
                            var val = data.Substring(data.IndexOf('['), 1);
                            stream.Close();
                            client.Close();
                        }
                        Thread.Sleep(500);
                    }

                }
            }

        }

        /// <summary>
        /// Get serialized string of all saves
        /// </summary>
        /// <returns></returns>
        public static string GetSaves()
        {
            var saveModel = new SaveModel();
            var saves = saveModel.getSaves();
            List<SaveTemp> saveTemps = new List<SaveTemp>();
            
            foreach (var save in saves)
            {
                SaveTemp saveTemp = new SaveTemp(save.saveName);
                saveTemps.Add(saveTemp);
            }
            var message = JsonSerializer.Serialize(saveTemps);

            return message;

        }

        class SaveTemp
        {
            public string Name { get; set; } = "";
            public int Percent { get; set; } = 0;
           public int State { get; set; } = 0;
            public SaveTemp(string name, int percent = 0, int state = 0)
            {
                Name = name;
                Percent = percent;
                State = state;
            }
        }

    }
}