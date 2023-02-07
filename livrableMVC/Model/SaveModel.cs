using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace livrableMVC.Model
{
    public class SaveModels
    {
        public string source { get; set; }
        public string destination { get; set; }
        public string saveName { get; set; }
        public long Size { get; set; }
        public DateTime Time { get; set; }
        public Boolean state { get; set; }
    }


    public class Saves
    {
        public string sourceTarget { get; set; }
        public string destinationTarget { get; set; }
        public string type { get; set; }
        public string saveName { get; set; }
    }


    internal class SaveModel
    {

        long time;
        public long executeSave(string saveName)
        {
            var sw = new Stopwatch();
            sw.Start();
            string save = "";
            string fileName = "..\\..\\..\\"+ saveName + ".json";
            save = System.IO.File.ReadAllText(fileName);
            Console.WriteLine(save);
            System.Threading.Thread.Sleep(10000);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            time = sw.ElapsedMilliseconds;
            return time ;
        }

        public long createNewSave(string sourceTargetEntry, string destinationTargetEntry, string typeEntry, string saveNameEntry) {
            var sw = new Stopwatch();
            sw.Start();
            var saves = new Saves()
            {
                sourceTarget = sourceTargetEntry,
                destinationTarget = destinationTargetEntry,
                type = typeEntry,
                saveName = saveNameEntry
            };

            string jsonString = JsonSerializer.Serialize(saves);
            string fileName = "..\\..\\..\\" + saveNameEntry + ".json";
        
            File.AppendAllText(fileName, jsonString);
           
            Console.WriteLine(jsonString);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            time = sw.ElapsedMilliseconds;
            return time;
        }

        public Saves ReadSaveTemplate(string jsonPath)
        {
            var JsonFile = System.IO.File.ReadAllText(jsonPath);
            Saves save =
                JsonSerializer.Deserialize<Saves>(JsonFile);

            return save;
           
        }
    }
}
