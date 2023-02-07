using livrableMVC.Model;
using livrableMVC.View;
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
        public LanguageModel langModel { get; set; }
        public SaveModel saveModel { get; set; }
        public LanguageView langView { get; set; }
        public MainView mainView { get; set; }
        public SaveView saveView { get; set; }
        public ExecuteView executeView { get; set; }

        Dictionary<string, string> sentences = new Dictionary<string, string>();

        public Controller()
        {
            saveModel = new SaveModel();
            langModel = new LanguageModel();
            langView = new LanguageView();
            saveView = new SaveView();
            mainView = new MainView();
            executeView = new ExecuteView();
        }
        public void start()
        {
            languageUsed = langView.Start(langModel.languages("eng"));
            while (true)
            {
                Console.Clear();
                int val = mainView.Start(0, 1, langModel.languages(languageUsed));
                Console.Clear();
                switch (val)
                {
                    case 1:
                        var result = saveView.Start(langModel.languages(languageUsed), 0, 0);
                        break;
                    case 2:
                        var res = new List<string>();
                        res = executeView.Start(new List<string> { "t", "e", "s", "t"});
                        break;
                    case 3:
                        languageUsed = langView.Start(langModel.languages(languageUsed));
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void saveSetting()
        {
            saveModel.createNewSave("C:/", "D:/", "COMPLETE", "first");
        }
        public void execSaveSetting()
        {
            saveModel.executeSave("first");
        }

    
        public void languageSettings()
        {
           
            while (!languageUsed.Equals("eng") && !languageUsed.Equals("fr"))
            {
                Console.WriteLine("Please unter your language :");
                Console.WriteLine("Merci d'indiquer la langue souhaiter:");
                Console.WriteLine("eng = Engish / fr = Français");
                languageUsed = Console.ReadLine();
            }
            Console.Clear();
            sentences = langModel.languages(languageUsed);
            Console.WriteLine(sentences["hello"]);

        }
    }
}