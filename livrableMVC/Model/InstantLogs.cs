using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace livrableMVC.Model
{
    internal class InstantLogsModel
    {
        public string Name { get; set; }
        public string FileSource { get; set; }
        public string FileTarget { get; set; }
        public Boolean state { get; set; }
        public int TotalFilesSize { get; set; }
        public int NbFilesLeftToDo { get; set; }
        public int progression { get; set; }
        public DateTime date { get; set; }

    }

    public class InstantLogs
    {
        public void InstantLogsFunction(string saveNameEntry, string sourceTargetEntry, string destinationTargetEntry, string saveSizeEntry, long saveTimeEntry, DateTime dateEntry)
        {
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
            string fileName = "..\\..\\..\\dailyLogs.json";
            File.AppendAllText(fileName, jsonString);
            Console.WriteLine(jsonString);
        }

    }
}
