using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.Model
{
    internal class LanguageModel
    {
        public LanguageModel() { }
        Dictionary<string, string> french = new Dictionary<string, string>
    {
        { "hello" , "Bonjour et bienvenue dans votre solution de sauvegarde !" },
        {"exit", "Quitter"},
        {"execute", "Executer"},
        {"save","Enregistrer" },
        {"english", "Anglais" },
        {"french", "Francais" }
    };
        Dictionary<string, string> english = new Dictionary<string, string>
    {
        { "hello" , "Hello, welcome to your save solution !" },
        {"exit", "Exit"},
        {"execute", "Execute"},
        {"save","Save" },
        {"english", "English" },
        {"french", "French" }
    };


        public Dictionary<string, string> languages(string lang)
        {
            if (lang.Equals("eng"))
            {
                return english;
            }
            else
            {
                return french;
            }
        }
    }
}
