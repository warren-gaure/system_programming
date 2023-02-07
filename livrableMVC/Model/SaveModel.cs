using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        long filesDone = 0;
        public Saves executeSave(string saveName)
        {
            string save = "";
            string fileName = "..\\..\\..\\repoSaves\\" + saveName;
            save = System.IO.File.ReadAllText(fileName);
            Saves? saveFromFile = JsonSerializer.Deserialize<Saves>(save);

            try
            {
                Directory.CreateDirectory(saveFromFile.destinationTarget);
                switch (saveFromFile.type)
                {
                    case "COMPLETE":
                        CopyDirectoryComplete(saveFromFile.sourceTarget, saveFromFile.destinationTarget);
                        Console.WriteLine("Backup type complete completed successfully.");

                        break;
                    case "DIFFERENTIAL":
                        CopyDirectoryDifferential(saveFromFile.sourceTarget, saveFromFile.destinationTarget);
                        Console.WriteLine("Backup type complete differential successfully.");
                        break;
                    default: 
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            
            return saveFromFile;
        }

        private long CopyDirectoryComplete(string sourceDirectory, string targetDirectory) 
        {
            DirectoryInfo source = new DirectoryInfo(sourceDirectory);
            DirectoryInfo target = new DirectoryInfo(targetDirectory);
            if (target.Exists) target.Delete(true);

            target.Create();

            foreach (FileInfo file in source.GetFiles()) { 
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
                filesDone++;
            }

            foreach (DirectoryInfo subDirectory in source.GetDirectories())
                CopyDirectoryComplete(subDirectory.FullName, Path.Combine(target.FullName, subDirectory.Name));

            return filesDone;
        }

        private long CopyDirectoryDifferential(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo source = new DirectoryInfo(sourceDirectory);
            DirectoryInfo target = new DirectoryInfo(targetDirectory);

            if (!target.Exists)
                target.Create();

            foreach (FileInfo file in source.GetFiles())
            {
                FileInfo targetFile = new FileInfo(Path.Combine(target.FullName, file.Name));
                if (!targetFile.Exists || file.LastWriteTime > targetFile.LastWriteTime)
                {
                    file.CopyTo(targetFile.FullName, true);
                }
                filesDone++;
            }

            foreach (DirectoryInfo subDirectory in source.GetDirectories())
            {
                DirectoryInfo targetSubDirectory = new DirectoryInfo(Path.Combine(target.FullName, subDirectory.Name));
                CopyDirectoryDifferential(subDirectory.FullName, targetSubDirectory.FullName);
            }
            return filesDone;
        }

        public bool createNewSave(string sourceTargetEntry, string destinationTargetEntry, string typeEntry, string saveNameEntry) {
            var saves = new Saves()
            {
                sourceTarget = sourceTargetEntry,
                destinationTarget = destinationTargetEntry,
                type = typeEntry,
                saveName = saveNameEntry
            };

            string jsonString = JsonSerializer.Serialize(saves);
            string fileName = "..\\..\\..\\repoSaves\\" + saveNameEntry + ".json";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.AppendAllText(fileName, jsonString);
            return true;
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
