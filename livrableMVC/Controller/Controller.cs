using livrableMVC.Model;
using livrableMVC.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace livrableMVC.ControllerSpace
{
    internal class Controller
    {
        string languageUsed = "";
        LanguageModel lang = new LanguageModel();
        SaveModel saveModel = new SaveModel();
        DailyLogs dailyLogs = new DailyLogs(); 
        Dictionary<string, string> sentences = new Dictionary<string, string>();
        long timeExec;
        long timeCreate;
        long globalTime;

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

        public long saveSetting()
        {
            timeCreate = saveModel.createNewSave("C:/", "D:/", "COMPLETE", "first");
            globalTimeCreate();
            return timeCreate;
        }
        public long execSaveSetting()
        {
            timeExec = saveModel.executeSave("first");
            globalTimeExec();
            return timeExec;
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