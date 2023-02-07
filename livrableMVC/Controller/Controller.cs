using livrableMVC.Model;
using livrableMVC.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
        Saves savesModel = new Saves();
        long timeExec;
        long timeCreate;
        bool execValidate;
        long globalTime;
        long GlobalFileSize;
        long curentTransfertFiles;
        long progression;
        int filesNumber = 0;
        int fileLeftToDo = 0;
        int fileDo = 0;


        string repoSourceTest = "..\\..\\..\\test\\";

        /// <summary>
        /// function to call savemodel createNewSave
        /// </summary>
        /// <param name="sourceTargetEntry"></param>
        /// <param name="destinationTargetEntry"></param>
        /// <param name="typeEntry"></param>
        /// <param name="saveNameEntry"></param>
        /// <returns></returns>
        public bool saveSetting(string sourceTargetEntry, string destinationTargetEntry, string typeEntry, string saveNameEntry)
        {
            execValidate = saveModel.createNewSave(sourceTargetEntry, destinationTargetEntry, typeEntry, saveNameEntry);
            return execValidate;
        }
        /// <summary>
        /// function main
        /// it's called by Program Main
        /// Call language view to get the language
        /// </summary>
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
                        saveSetting(result[1], result[2], result[3], result[0]);
                        break;
                    case 2:
                        
                        var res = executeView.Start(fileModel.getSaves(), langModel.languages(languageUsed));
                        Thread instantLogs = new Thread(() => { Console.WriteLine("test"); });
                        foreach (var save in res)
                        {
                            var sw = new Stopwatch();
                            sw.Start();
                            instantLogs.Start();
                            savesModel = saveModel.executeSave(save);
                            sw.Stop();
                            long time = sw.ElapsedMilliseconds;
                            dailyLogs.DailyLogsFunction(savesModel.saveName, savesModel.sourceTarget, savesModel.destinationTarget, savesModel.type, time, DateTime.Now); 
                        }
                        instantLogs.Abort();
                        break;
                    case 3:
                        languageUsed = langView.Start(langModel.languages(languageUsed));
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        public long globalTimeExec()
        {
            globalTime += timeExec;
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