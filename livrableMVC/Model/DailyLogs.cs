using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace livrableMVC.Model
{
    public class DailyLogsModel
    {
        public string saveName { get; set; }
        public string sourceTarget { get; set; }
        public string destinationTarget { get; set; }
        public string saveSize { get; set; }
        public long saveTime { get; set; }
        public DateTime date { get; set; }
    }

    public class DailyLogs
    {
        
        public void DailyLogsFunction(string saveNameEntry, string sourceTargetEntry, string destinationTargetEntry, string saveSizeEntry, long saveTimeEntry, DateTime dateEntry) {
            var dailyLogs = new DailyLogsModel()
            {
                saveName = saveNameEntry,
                sourceTarget = sourceTargetEntry,
                destinationTarget = destinationTargetEntry,
                saveSize = saveSizeEntry,
                saveTime = saveTimeEntry,
                date = dateEntry,
            };
            string jsonString = JsonSerializer.Serialize(dailyLogs);
            string fileName = "..\\..\\..\\dailyLogs"+ DateTime.Now.ToString("yyyyMMdd") + ".json";
            File.AppendAllText(fileName, jsonString);
            Console.WriteLine(jsonString);
        }
       
    }
}
