using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.View
{
    internal class ExecuteView
    {
        public ExecuteView() {}

        /// <summary>
        /// Display saves and return list of saves selected by user (index of save separated by ',')
        /// if there is no save display a message for 3 seconds
        /// </summary>
        /// <param name="saves"></param>
        /// <param name="sentences"></param>
        /// <returns></returns>
        public List<string> Start(List<string> saves, Dictionary<string, string> sentences)
        {
            var result = new List<string>();
            if (saves.Count > 0)
            {
                for (int i = 1; i <= saves.Count(); i++)
                {
                    Console.WriteLine(i + "- " + saves[i - 1]);
                }
                var res = Console.ReadLine();
                if (!string.IsNullOrEmpty(res))
                {
                    string[] val = res.Split(",");
                    foreach (string s in val)
                    {
                        int temp = -1;
                        if (int.TryParse(s, out temp))
                        {
                            try
                            {
                                result.Add(saves[temp - 1]);
                            }
                            catch { }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(sentences["noSaveFound"]);
                Thread.Sleep(3000);
            }
            return result;
        }
        
    }
}
