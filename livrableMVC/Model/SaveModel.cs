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
            //Console.WriteLine(save);
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
                        Directory.GetFiles(saveFromFile.sourceTarget, "*.*", SearchOption.AllDirectories)
                        .ToList()
                        .ForEach(file =>
                        {
                            string targetFile = file.Replace(saveFromFile.sourceTarget, saveFromFile.destinationTarget);
                            if (!File.Exists(targetFile) || File.GetLastWriteTime(file) > File.GetLastWriteTime(targetFile))
                            {
                                File.Copy(file, targetFile, true);
                            }
                        });
                        Console.WriteLine("Backup type diff completed successfully.");
                        break;
                    default: 
                        break;
                }
            }
            catch (Exception ex)
            {

            }



            System.Threading.Thread.Sleep(5000);
            sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            time = sw.ElapsedMilliseconds;
            return time ;
        }

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
            if (!File.Exists(fileName))
            {
                File.AppendAllText(fileName, jsonString);
            }
            else
            {

            }
            //Console.WriteLine(jsonString);
            sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            time = sw.ElapsedMilliseconds;
            return time;
        }
    }
}
