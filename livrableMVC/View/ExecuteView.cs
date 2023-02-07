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

        public List<string> Start(List<string> saves)
        {
            for(int i = 1; i <= saves.Count(); i++)
            {
                Console.WriteLine(i + "- " + saves[i-1]);
            }
            var res = Console.ReadLine();
            var result = new List<string>();
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
                            result.Add(saves[temp-1]);
                        }
                        catch { }
                    }
                }
            }            
            return result;
        }
        
    }
}
