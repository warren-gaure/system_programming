using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVVM.Model
{
    internal class LanguageModel
    {
        public LanguageModel() { }
        Dictionary<string, string> french = new Dictionary<string, string>
    {
        { "hello" , "Bonjour et bienvenue dans votre solution de sauvegarde !" },
        {"exit", "Quitter"},
        {"execute", "Exécuter"},
        {"save","Enregistrer" },
        {"english", "Anglais" },
        {"french", "Francais" },
        {"name", "Nom :" },
        {"source", "Source :" },
        {"target", "Cible :" },
        {"type", "Type" },
        {"complete", "complete"},
        {"diff", "différentiel" },
        {"changeLang", "Changer la langue" },
        {"selectLang", "Sélectionner une langue :" },
        {"noSaveFound", "Aucune sauvegarde trouvé" },
        {"createTitle","Création" },
        {"createDetails","Entrer les informations pour créer la sauvegarde" },
        {"encryption","Cryptage : (exe, txt, ...)" },
        {"create","Créer" },
        {"typeOfSave","Type de sauvegarde :" },
        {"executeTitle","Executer" },
        {"executeDetails","Sélectionner une sauvegarde à éxecuter" },
        {"typeOfLog","Type de log :" },
        {"optionTitle","Options" },
        {"optionDetails","Options de l'application" },
        {"language","Langage" },
        {"businessSoftware","Logiciel Metier :" },
        {"homeTitle","Accueil" },

    };
        Dictionary<string, string> english = new Dictionary<string, string>
    {
        { "hello" , "Hello, welcome to your save solution !" },
        {"exit", "Exit"},
        {"execute", "Execute"},
        {"save","Save" },
        {"english", "English" },
        {"french", "French" },
        {"name", "Name :" },
        {"source", "Source :" },
        {"target", "Target :" },
        {"type", "Type" },
        {"complete", "complete"},
        {"diff", "differential" },
        {"changeLang", "Change the language" },
        {"selectLang", "Select a language :" },
        {"noSaveFound", "No save found" },
        {"createTitle","Creation" },
        {"createDetails","Enter informations to create a save" },
        {"encryption","Encryption : (exe, txt, ...)" },
        {"create","Create" },
        {"typeOfSave","Type of save :" },
        {"executeTitle","Execute" },
        {"executeDetails","Please Select a save to Execute" },
        {"typeOfLog","Type of log :" },
        {"optionTitle","Option" },
        {"optionDetails","Options of the application" },
        {"language","Language" },
        {"businessSoftware","Business Software :" },
        {"homeTitle","Home" },

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
