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
        LanguageModel lang = new LanguageModel();
        SaveModel saveModel = new SaveModel();
        FileModel filemodel= new FileModel();
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


        string repoSourceTest = "D:\\cours\\CESI2022-2023\\ProgramationSystem\\programmation_systeme\\livrableMVC\\test\\";


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

            public long saveSetting()
        {
            timeCreate = saveModel.createNewSave("C:\\Users\\mallo\\OneDrive\\Bureau\\CESI 2022 - 2025\\Année 3 (1)\\Semestre 5\\Programmation système\\Projet\\TEST Source", "C:\\Users\\mallo\\OneDrive\\Bureau\\CESI 2022 - 2025\\Année 3 (1)\\Semestre 5\\Programmation système\\Projet\\TEST Destination", "COMPLETE", "first");
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

        public long progressionFunction ()
        {
            List<String> files = new List<String>();
            files = filemodel.FileList(repoSourceTest);

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
            progression = GlobalFileSize * 100 / curentTransfertFiles;
            fileLeftToDo = filesNumber - fileDo;
            instantLogs.InstantLogsFunction("test", "test", "test", true, GlobalFileSize, 10, progression, DateTime.Now);
            globalTime = 0;
        }

        public void readSaves()
        {
            saveModel.ReadSaveTemplate("D:\\cours\\CESI2022-2023\\ProgramationSystem\\programmation_systeme\\livrableMVC\\first.json");
        }
    }
}