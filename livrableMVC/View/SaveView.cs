using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using livrableMVC.ControllerSpace;
using livrableMVC.Model;

namespace livrableMVC.View
{
    internal class SaveView
    {
        public SaveView() { }

        public List<string> Start(Dictionary<string, string> sentences, int left = 0, int top = 0)
        {
            var result = new List<string>();
            Console.WriteLine(sentences["name"]);
            result.Add(Console.ReadLine());
            Console.WriteLine(sentences["source"]);
            result.Add(Console.ReadLine());
            Console.WriteLine(sentences["target"]);
            result.Add(Console.ReadLine());
            Console.WriteLine(sentences["type"]);
            result.Add(Console.ReadLine());
            return result;
        }

    }
}
