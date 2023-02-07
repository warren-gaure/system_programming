using livrableMVC.Model;
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
                Console.WriteLine("Welcome ! / Bienvenue !");
                Console.WriteLine("Please select your prefered language / Merci d'indiquer votre langue souhaitée");
                Console.WriteLine("eng = English / fr = Français");
                languageUsed = Console.ReadLine();
            }
            Console.Clear();
            sentences = lang.languages(languageUsed);
            Console.WriteLine(sentences["hello"]);
        }

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

        public long globalTimeExec()
        {
            globalTime += timeExec;
            return globalTime;
        }
        public long globalTimeCreate()
        {
            globalTime += timeCreate;
            return globalTime;
        }

        public void dailyLogsFunction()
        {
            dailyLogs.DailyLogsFunction("test", "test", "test", "test", globalTime, DateTime.Now);
            globalTime = 0;
        }
    }

}