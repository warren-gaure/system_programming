using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Livrable3.Model
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
        {"french", "Francais" },
        {"name", "Nom" },
        {"source", "Source" },
        {"target", "Cible" },
        {"type", "Type" },
        {"complete", "complete"},
        {"diff", "différentiel" },
        {"changeLang", "Changer la langue" },
        {"selectLang", "Sélectionner une langue" },
        {"noSaveFound", "Aucune sauvegarde trouvé" }
    };
        Dictionary<string, string> english = new Dictionary<string, string>
    {
        { "hello" , "Hello, welcome to your save solution !" },
        {"exit", "Exit"},
        {"execute", "Execute"},
        {"save","Save" },
        {"english", "English" },
        {"french", "French" },
        {"name", "Name" },
        {"source", "Source" },
        {"target", "Target" },
        {"type", "Type" },
        {"complete", "complete"},
        {"diff", "differential" },
        {"changeLang", "Change the language" },
        {"selectLang", "Select a language" },
        {"noSaveFound", "No save found" }
    };

        /// <summary>
        /// return the dictinnary of the language asked
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
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
