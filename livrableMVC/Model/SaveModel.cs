using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace livrableMVC.Model
{

    public class Saves
    {
        public string sourceTarget { get; set; }
        public string destinationTarget { get; set; }
        public string type { get; set; }
        public string saveName { get; set; }
    }


    internal class SaveModel
    {
        public Boolean executeSave(string saveName)
        {
            string save = "";
            string fileName = "..\\..\\..\\Save.json";
            
            foreach (string line in System.IO.File.ReadLines(fileName))
            {
                if (line.Contains(saveName))
                {
                    save = line;
                }
            }
            Console.WriteLine(save);
            return true;
        }

        public Boolean createNewSave(string sourceTargetEntry, string destinationTargetEntry, string typeEntry, string saveNameEntry) {

            var saves = new Saves()
            {
                sourceTarget = sourceTargetEntry,
                destinationTarget = destinationTargetEntry,
                type = typeEntry,
                saveName = saveNameEntry
            };

            string jsonString = JsonSerializer.Serialize(saves);
            string fileName = "..\\..\\..\\Save.json";
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, jsonString);
            }
            Console.WriteLine(jsonString);
            Console.WriteLine(File.ReadAllText(fileName));

            return true;
        }
    }
}
