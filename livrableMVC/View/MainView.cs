using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.View
{
    internal class MainView
    {
        public MainView() { }

        public int Start(int left, int top, Dictionary<string, string> sentences)
        {
            var result = 0;
            Console.WriteLine("1- " + sentences["save"]);
            Console.WriteLine("2- " + sentences["execute"]);
            Console.WriteLine("3- " + sentences["changeLang"]);
            Console.WriteLine("4- " + sentences["exit"]);
            int.TryParse(Console.ReadLine(), out result);
            return result;
        }
    }
}
