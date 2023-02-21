﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace livrableMVVM.Model
{
    public class DailyLogsModel
    {
        public string saveName { get; set; }
        public string sourceTarget { get; set; }
        public string destinationTarget { get; set; }
        public string saveSize { get; set; }
        public long saveTime { get; set; }
        public DateTime date { get; set; }
        public long encryptionTime { get; set; }
    }

    public class DailyLogs
    {
        /// <summary>
        /// Create a DailyLogsModel, serialize it, create a json file, write the serialized object to the file and write the serialized object
        /// </summary>
        /// <param name="saveNameEntry"></param>
        /// <param name="sourceTargetEntry"></param>
        /// <param name="destinationTargetEntry"></param>
        /// <param name="saveSizeEntry"></param>
        /// <param name="saveTimeEntry"></param>
        /// <param name="dateEntry"></param>
        /// <param name="encryptionTime"></param>
        public void DailyLogsFunction(string saveNameEntry, string sourceTargetEntry, string destinationTargetEntry, string saveSizeEntry, long saveTimeEntry, DateTime dateEntry, long encryptionTime)
        {
            var dailyLogs = new DailyLogsModel()
            {
                saveName = saveNameEntry,
                sourceTarget = sourceTargetEntry,
                destinationTarget = destinationTargetEntry,
                saveSize = saveSizeEntry,
                saveTime = saveTimeEntry,
                date = dateEntry,
                encryptionTime = encryptionTime
            };
            string jsonString = JsonSerializer.Serialize(dailyLogs);
            string fileName = "..\\..\\..\\dailyLogs" + DateTime.Now.ToString("yyyyMMdd") + ".json";
            jsonString += "\n";
            File.AppendAllText(fileName, jsonString);


        }

        /// <summary>
        /// This method takes all attributes of a DailyLogs object and saves them in a newly created .XML file.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="size"></param>
        /// <param name="time"></param>
        /// <param name="date"></param>
        /// <param name="encryption"></param>
        public void dailyLogToXML(string name, string source, string destination, string size, long time, DateTime date, long encryption)
        {
            string fileName = "..\\..\\..\\dailyLogs" + DateTime.Now.ToString("yyyyMMdd") + ".xml";
            string xmlString =
                @"<?xml version=""1.0"" encoding=""utf-8""?>" +
                "\n<DailyLog>\n" +
                    $"<Name>{name}</Name>\n" +
                    $"<Source>{source}</Source>\n" +
                    $"<Destination>{destination}</Destination>\n" +
                    $"<Size>{size}</Size>\n" +
                    $"<Time>{time}</Time>\n" +
                    $"<Date>{date}</Date>\n" +
                    $"<EncryptionTime>{encryption}</Encryption>" +
                "</DailyLog>\n";
            File.AppendAllText(fileName, xmlString);
        }


    }
}