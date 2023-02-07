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
        /// <summary>
        /// take the save's name, get the save from the file, if the save is complete call CopyDirectoryComplete if the save is differential call CopyDirectoryDifferential
        /// </summary>
        /// <param name="saveName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Copy all file from sourceDirectory to targetDirectory
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        private void CopyDirectoryComplete(string sourceDirectory, string targetDirectory) 
        {
            DirectoryInfo source = new DirectoryInfo(sourceDirectory);
            DirectoryInfo target = new DirectoryInfo(targetDirectory);
            if (target.Exists) target.Delete(true);

            target.Create();

            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);

            foreach (DirectoryInfo subDirectory in source.GetDirectories())
                CopyDirectoryComplete(subDirectory.FullName, Path.Combine(target.FullName, subDirectory.Name));
        }

        /// <summary>
        /// Copy all modified file or new file from sourceDirectory to targetDirectory
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        private void CopyDirectoryDifferential(string sourceDirectory, string targetDirectory)
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
            }

            foreach (DirectoryInfo subDirectory in source.GetDirectories())
            {
                DirectoryInfo targetSubDirectory = new DirectoryInfo(Path.Combine(target.FullName, subDirectory.Name));
                CopyDirectoryDifferential(subDirectory.FullName, targetSubDirectory.FullName);
            }
        }

        /// <summary>
        /// create a new saves, serialize it, create json file (if already exist delete it) and write serialized object in the file
        /// </summary>
        /// <param name="sourceTargetEntry"></param>
        /// <param name="destinationTargetEntry"></param>
        /// <param name="typeEntry"></param>
        /// <param name="saveNameEntry"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// deserialize a save from jsonpath
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        public Saves ReadSaveTemplate(string jsonPath)
        {
            var JsonFile = System.IO.File.ReadAllText(jsonPath);
            Saves save =
                JsonSerializer.Deserialize<Saves>(JsonFile);

            return save;
           
        }
    }
}
