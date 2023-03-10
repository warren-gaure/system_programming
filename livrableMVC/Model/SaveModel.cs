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


    internal class SaveModel : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        string name { get; set; }
        string source { get; set; }
        string dest { get; set; }

        bool state { get; set; }
        long totalFilesSize { get; set; }
        long nbTotalFiles { get; set; }
        int nbFIlesLeftToDo { get; set; }

        int progresseion { get; set; }
        int filesDone { get; set; }



        long time { get; set; }

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
            name = saveFromFile.saveName;
            source = saveFromFile.sourceTarget;
            dest = saveFromFile.destinationTarget;
            filesDone = 0;
            nbFIlesLeftToDo = 0;
            totalFilesSize= 0;
            state = false;
            List<long> temp = TotalFilesNumberAndSizeFunction(source);
            totalFilesSize = temp[0];
            nbTotalFiles = temp[1];

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
        private long CopyDirectoryComplete(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo source = new DirectoryInfo(sourceDirectory);
            DirectoryInfo target = new DirectoryInfo(targetDirectory);
            if (target.Exists) target.Delete(true);

            target.Create();

            foreach (FileInfo file in source.GetFiles())
            {
                Notify();
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
                filesDone++;
                Notify();
            }

            foreach (DirectoryInfo subDirectory in source.GetDirectories())
                CopyDirectoryComplete(subDirectory.FullName, Path.Combine(target.FullName, subDirectory.Name));

            return filesDone;
        }
        /// <summary>
        /// Copy all modified file or new file from sourceDirectory to targetDirectory
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        private long CopyDirectoryDifferential(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo source = new DirectoryInfo(sourceDirectory);
            DirectoryInfo target = new DirectoryInfo(targetDirectory);

            if (!target.Exists)
                target.Create();

            foreach (FileInfo file in source.GetFiles())
            {
                Notify();
                FileInfo targetFile = new FileInfo(Path.Combine(target.FullName, file.Name));
                if (!targetFile.Exists || file.LastWriteTime > targetFile.LastWriteTime)
                {
                    file.CopyTo(targetFile.FullName, true);
                }
                filesDone++;
                Notify();
            }

            foreach (DirectoryInfo subDirectory in source.GetDirectories())
            {
                DirectoryInfo targetSubDirectory = new DirectoryInfo(Path.Combine(target.FullName, subDirectory.Name));
                CopyDirectoryDifferential(subDirectory.FullName, targetSubDirectory.FullName);
            }
            return filesDone;
        }

        /// <summary>
        /// create a new saves, serialize it, create json file (if already exist delete it) and write serialized object in the file
        /// </summary>
        /// <param name="sourceTargetEntry"></param>
        /// <param name="destinationTargetEntry"></param>
        /// <param name="typeEntry"></param>
        /// <param name="saveNameEntry"></param>
        /// <returns></returns>
        public bool createNewSave(string sourceTargetEntry, string destinationTargetEntry, string typeEntry, string saveNameEntry)
        {
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
            jsonString += "\n";

            File.AppendAllText(fileName, jsonString);
            return true;
        }


        public string[] GetData()
        {
            progresseion = filesDone * 100 / (int)nbTotalFiles;
            nbFIlesLeftToDo = (int)nbTotalFiles - filesDone;
            if (progresseion >= 100)
            {
                state = true;
            }
            string[] temp = { name, source, dest, state.ToString(), totalFilesSize.ToString(), nbFIlesLeftToDo.ToString(), progresseion.ToString() };

            return temp;
        }

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }

        }
        public List<long> TotalFilesNumberAndSizeFunction(string directoryPath)
        {
            
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            // Add file sizes.
            FileInfo[] fis = directoryInfo.GetFiles();
            foreach (FileInfo fi in fis)
            {
                totalFilesSize += fi.Length;
                nbTotalFiles++;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = directoryInfo.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                totalFilesSize += TotalFilesNumberAndSizeFunction(di.FullName)[0];
            }
            return new List<long> { totalFilesSize, nbTotalFiles };
        }
    }
}
