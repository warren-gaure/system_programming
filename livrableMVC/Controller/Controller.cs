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
        SaveModel saveModel = new SaveModel();
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
            Console.WriteLine(sentences["hello"]);
            sentences = lang.languages(languageUsed);

        }

        public void saveSetting()
        {
            saveModel.createNewSave("C:/", "D:/", "COMPLETE", "first");
        }
        public void execSaveSetting()
        {
            saveModel.executeSave("first");
        }
    }

}