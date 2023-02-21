using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.View
{
    internal class LanguageView
    {
        LanguageModel lang = new LanguageModel();
        public LanguageView() { }
        
        /// <summary>
        /// Display the banner, display languages and return language selected
        /// </summary>
        /// <param name="sentences"></param>
        /// <returns></returns>
        public string Start(Dictionary<string, string> sentences)
        {
            Console.WriteLine("         \r\n██████╗ ██████╗  ██████╗ ███████╗ ██████╗ ███████╗████████╗\r\n██╔══██╗██╔══██╗██╔═══██╗██╔════╝██╔═══██╗██╔════╝╚══██╔══╝\r\n██████╔╝██████╔╝██║   ██║███████╗██║   ██║█████╗     ██║   \r\n██╔═══╝ ██╔══██╗██║   ██║╚════██║██║   ██║██╔══╝     ██║   \r\n██║     ██║  ██║╚██████╔╝███████║╚██████╔╝██║        ██║   \r\n╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚══════╝ ╚═════╝ ╚═╝        ╚═╝   ");
            Console.WriteLine(sentences["selectLang"]);
            var result = 0;
            Console.WriteLine("1- " + sentences["english"]);
            Console.WriteLine("2- " + sentences["french"]);
            int.TryParse(Console.ReadLine(), out result);
            if(result == 2) { return "fr"; }
            else { return "eng"; }
        }
    }
}
