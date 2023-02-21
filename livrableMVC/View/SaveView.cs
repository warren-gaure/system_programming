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

        /// <summary>
        /// ask the user to enter a name, a folder source, a folder target and a type
        /// type as to be COMPLETE or DIFFERENTIAL and keep asking while it's not valid
        /// </summary>
        /// <param name="sentences"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<string> Start(Dictionary<string, string> sentences, int left = 0, int top = 0)
        {
            var result = new List<string>();
            Console.WriteLine(sentences["name"]);
            result.Add(Console.ReadLine());
            Console.WriteLine(sentences["source"]);
            result.Add(Console.ReadLine());
            Console.WriteLine(sentences["target"]);
            result.Add(Console.ReadLine());
            Console.WriteLine(sentences["type"] + " (COMPLETE / DIFFERENTIAL)" );
            var type = "";
            while(type != "COMPLETE" && type != "DIFFERENTIAL")
            {
                type = Console.ReadLine();
            }
            result.Add(type);
            return result;
        }

    }
}
