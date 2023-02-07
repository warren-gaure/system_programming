﻿using System;
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
        public long TotalFilesSize { get; set; }
        public int NbFilesLeftToDo { get; set; }
        public long progression { get; set; }
        public DateTime date { get; set; }

    }

    public class InstantLogs
    {
        /// <summary>
        /// Create a InstantLogsModel serialize it, create a file in instantLogs, write the serialized object in the file and write the serialized object
        /// </summary>
        /// <param name="NameEntry"></param>
        /// <param name="FileSourceEntry"></param>
        /// <param name="destinationTargetEntry"></param>
        /// <param name="stateEntry"></param>
        /// <param name="TotalFilesSizeEntry"></param>
        /// <param name="NbFilesLeftToDoEntry"></param>
        /// <param name="progressionEntry"></param>
        /// <param name="dateEntry"></param>
        public void InstantLogsFunction(string NameEntry, string FileSourceEntry, string destinationTargetEntry, Boolean stateEntry, long TotalFilesSizeEntry,int NbFilesLeftToDoEntry, long progressionEntry, DateTime dateEntry)
        {
            var instantLogs = new InstantLogsModel()
            {
                Name = NameEntry,
                FileSource = FileSourceEntry,
                FileTarget = destinationTargetEntry,
                state = stateEntry,
                TotalFilesSize = TotalFilesSizeEntry,
                NbFilesLeftToDo = NbFilesLeftToDoEntry,
                progression = progressionEntry,
                date = dateEntry,
            };
            string jsonString = JsonSerializer.Serialize(instantLogs);
            string fileName = "..\\..\\..\\instantLogs"+ DateTime.Now.ToString("yyyyMMdd") + ".json";
            File.AppendAllText(fileName, jsonString);
            Console.WriteLine(jsonString);
        }

    }
}
