using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.ControllerSpace
{
    internal class Controller
    {
        string languageUsed = "";
        LanguageModel lang = new LanguageModel();
        Dictionary<string, string> sentences = new Dictionary<string, string>();

        public void languageSettings()
        {
           
            while (!languageUsed.Equals("eng") && !languageUsed.Equals("fr"))
            {
                Console.WriteLine("Please unter your language :");
                Console.WriteLine("Merci d'indiquer la langue souhaiter:");
                Console.WriteLine("eng = Engish / fr = Français");
                languageUsed = Console.ReadLine();
            }
            sentences = lang.languages(languageUsed);
            Console.WriteLine(sentences["hello"]);
        }
    }

}