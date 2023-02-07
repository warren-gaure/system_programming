using livrableMVC.Model;
using livrableMVC.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace livrableMVC.ControllerSpace
{
    internal class Controller
    {
        string languageUsed = "";

        LanguageView langView = new LanguageView();
        SaveView saveView = new SaveView();
        MainView mainView = new MainView();
        ExecuteView executeView = new ExecuteView();
        LanguageModel langModel = new LanguageModel();
        SaveModel saveModel = new SaveModel();
        FileModel fileModel= new FileModel();
        DailyLogs dailyLogs = new DailyLogs(); 
        InstantLogs instantLogs = new InstantLogs();
        Dictionary<string, string> sentences = new Dictionary<string, string>();
        long timeExec;
        long timeCreate;
        long globalTime;
        long GlobalFileSize;
        long curentTransfertFiles;
        long progression;
        int filesNumber = 0;
        int fileLeftToDo = 0;
        int fileDo = 0;


        string repoSourceTest = "..\\..\\..\\test\\";

        public long saveSetting()
        {
            timeCreate = saveModel.createNewSave("C:\\Users\\mallo\\OneDrive\\Bureau\\CESI 2022 - 2025\\Année 3 (1)\\Semestre 5\\Programmation système\\Projet\\TEST Source", "C:\\Users\\mallo\\OneDrive\\Bureau\\CESI 2022 - 2025\\Année 3 (1)\\Semestre 5\\Programmation système\\Projet\\TEST Destination", "COMPLETE", "first");
            globalTimeCreate();
            return timeCreate;
        }
        public void executeApplication()
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
                        var res = executeView.Start(fileModel.getSaves());
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

        public List<string> getAllSaves()
        {
            List<string> saves = fileModel.getSaves();

            return saves;
        }
        public long progressionFunction ()
        {
            List<String> files = new List<String>();
            files = fileModel.FileList(repoSourceTest);

            foreach (String file in files)
            {
                FileInfo fileinfo = new FileInfo(repoSourceTest+ file);
                Console.WriteLine(fileinfo.Length);
                GlobalFileSize += fileinfo.Length;
                filesNumber++;
            }
            Console.WriteLine(GlobalFileSize);
            return GlobalFileSize;
        }
        public void dailyLogsFunction()
        {
            dailyLogs.DailyLogsFunction("test", "test", "test", "test", globalTime, DateTime.Now);
            globalTime = 0;
        }
        public void instantLogsFunction()
        {
            /*progression = GlobalFileSize * 100 / curentTransfertFiles;
            fileLeftToDo = filesNumber - fileDo;
            instantLogs.InstantLogsFunction("test", "test", "test", true, GlobalFileSize, 10, progression, DateTime.Now);
            globalTime = 0;*/
        }

        public void readSaves()
        {
            saveModel.ReadSaveTemplate("..\\..\\..\\first.json");
        }
    }
}