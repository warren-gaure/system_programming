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
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace livrableMVC.ControllerSpace
{
    internal class Controller : IObserver
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
        bool execValidate;
       

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
        /// Call main View to get the function to do
        /// 1 => Create a new Save => Call save View and create a save with values returned by the view
        /// 2 => Execute Save(s) => Call execute View and execute saves returned
        /// 3 => Change language => Call language view and change languageUsed
        /// 4 => exit application
        /// </summary>
        public void executeApplication()
        {
            languageUsed = langView.Start(langModel.languages("eng"));
            while (true)
            {
                saveModel.Attach(this);
                Console.Clear();
                int val = mainView.Start(langModel.languages(languageUsed));
                Console.Clear();
                switch (val)
                {
                    case 1:
                        var result = saveView.Start(langModel.languages(languageUsed), 0, 0);
                        saveSetting(result[1], result[2], result[3], result[0]);
                        break;
                    case 2:
                        
                        var res = executeView.Start(fileModel.getSaves(), langModel.languages(languageUsed));
                        foreach (var save in res)
                        {
                            
                            var sw = new Stopwatch();
                            sw.Start();
                            savesModel = saveModel.executeSave(save);
                            sw.Stop();
                            long time = sw.ElapsedMilliseconds;
                            dailyLogs.DailyLogsFunction(savesModel.saveName, savesModel.sourceTarget, savesModel.destinationTarget, saveModel.GetData()[4], time, DateTime.Now); 
                            
                            
                        }
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
        

        /// <summary>
        /// return result of fileModel.getSaves
        /// </summary>
        /// <returns></returns>
        public List<string> getAllSaves()
        {
            List<string> saves = fileModel.getSaves();

            return saves;
        }


        

        void IObserver.Update(ISubject subject)
        {

            string[] temp = saveModel.GetData();
            Console.WriteLine("Observer update data : {0}",temp);
            instantLogs.InstantLogsFunction(temp[0], temp[1], temp[2], Convert.ToBoolean(temp[3]), long.Parse(temp[4]), Convert.ToInt32(temp[5]), long.Parse(temp[6]), DateTime.Now);
        }
    }
}