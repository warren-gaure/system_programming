using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;

namespace Livrable3.Model
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
        public string cryptage { get; set; }

        public Saves(string sourceTarget, string destinationTarget, string type, string saveName)
        {
            this.sourceTarget = sourceTarget;
            this.destinationTarget = destinationTarget;
            this.type = type;
            this.saveName = saveName;
        }
        public Saves(string sourceTarget, string destinationTarget, string type, string saveName, string cryptage)
        {
            this.sourceTarget = sourceTarget;
            this.destinationTarget = destinationTarget;
            this.type = type;
            this.saveName = saveName;
            this.cryptage = cryptage;
        }
        public Saves()
        {
            this.sourceTarget = "SourceTest";
            this.destinationTarget = "DestinationTest";
            this.type = "COMPLETE";
            this.saveName = "DefaultSave";
        }
    }

    internal class SaveModel : ISubject
    {
        public List<IObserver> _observers = new List<IObserver>();
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
        public Saves executeSave(Saves saveFromFile, List<FileInfo> filesToTransf)
        {
            name = saveFromFile.saveName;
            dest = saveFromFile.destinationTarget;
            List<FileInfo> fileToCopy = new List<FileInfo>();
            List<FileInfo> fileTemp = new List<FileInfo>();
            filesDone = 0;
            nbFIlesLeftToDo = 0;
            totalFilesSize = 0;
            state = false;
            List<long> temp = TotalFilesNumberAndSizeFunction(source);
            totalFilesSize = temp[0];
            nbTotalFiles = temp[1];
            DirectoryInfo target = new DirectoryInfo(dest);

            /* ----------------------------- */
            // Business Software Handling
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "CalculatorApp")
                {
                    process.WaitForExit();
                }
            }
            /* ----------------------------- */

            try
            {

                Directory.CreateDirectory(saveFromFile.destinationTarget);
                switch (saveFromFile.type)
                {
                    case "COMPLETE":
                        fileToCopy = filesToTransf;

                        break;
                    case "DIFFERENTIAL":
                        fileTemp = filesToTransf;

                        foreach (FileInfo file in fileTemp)
                        {
                            FileInfo targetFile = new FileInfo(System.IO.Path.Combine(target.FullName, file.Name));
                            if (!targetFile.Exists || file.LastWriteTime > targetFile.LastWriteTime)
                            {
                                fileToCopy.Add(file);
                            }
                        }
                        break;
                    default:
                        break;
                }
                CopyDirectory(fileToCopy, saveFromFile.destinationTarget);
                Console.WriteLine("Backup completed successfully.");
            }
            catch (Exception ex)
            {

            }

            return saveFromFile;
        }
        /// <summary>
        /// Copy all modified files or new files from sourceDirectory to targetDirectory
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        private void CopyDirectory(List<FileInfo> files, string targetDirectory)
        {
            // Mutex used to execute the foreach loop in more secure way
            Mutex mutex = new Mutex();

            DirectoryInfo target = new DirectoryInfo(targetDirectory);
            foreach (FileInfo file in files)
            {
                detectBusinessSoftware();
                // Blocking access to the critical section to one thread at the time
                mutex.WaitOne();

                /* ------------- CRITICAL SECTION ------------- */
                Notify();
                file.CopyTo(System.IO.Path.Combine(target.FullName, file.Name), true);
                filesDone++;
                Notify();
                /* -------------------------------------------- */
                
                // Releasing the mutex
                mutex.ReleaseMutex();
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
            string fileName = "..\\..\\..\\Saves\\AllSaves.json";

            if (File.Exists(fileName))
            {
                jsonString += "\n";
                File.AppendAllText(fileName, jsonString);
                return true;
            }
            else
            {
                File.Create(fileName);
                jsonString += "\n";
                File.AppendAllText(fileName, jsonString);
                return true;
            }

        }
        public bool createNewSave(string sourceTargetEntry, string destinationTargetEntry, string typeEntry, string saveNameEntry, string crypt)
        {
            var saves = new Saves()
            {
                sourceTarget = sourceTargetEntry,
                destinationTarget = destinationTargetEntry,
                type = typeEntry,
                saveName = saveNameEntry,
                cryptage = crypt
            };

            string jsonString = JsonSerializer.Serialize(saves);
            string fileName = "..\\..\\..\\Saves\\AllSaves.json";

            if (File.Exists(fileName))
            {
                jsonString += "\n";
                File.AppendAllText(fileName, jsonString );
                return true;
            }
            else
            {
                File.Create(fileName);
                jsonString += "\n";
                File.AppendAllText(fileName, jsonString );
                return true;
            }

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

        public List<FileInfo> nav(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            // Add file sizes.
            FileInfo[] fileInformation = directoryInfo.GetFiles();
            List<FileInfo> filesInfo = fileInformation.ToList();
            DirectoryInfo[] dis = directoryInfo.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                filesInfo = nav(di.FullName);
            }
            return filesInfo;
        }

        public void didCrypto(string[] extension, string path, string destPath, int key)
        {

            List<FileInfo> files = nav(path);
            foreach (string ext in extension)
            {
                foreach (FileInfo file in files)
                {
                    string fileExt = file.Name.Split('.').Last();
                    if (ext.Equals(fileExt))
                    {
                        Process cryptoSoft = new Process();
                        cryptoSoft.StartInfo.FileName = "CryptoSoft.exe";
                        cryptoSoft.StartInfo.Arguments = "\"" + file.FullName + "\" " + "\"" + destPath + "\" " + "\"" + key + "\"";
                        cryptoSoft.Start();
                    }
                }
            }
        }
        public List<FileInfo> ParamSend(string sourcePath, string extensions)
        {
            List<FileInfo> files = nav(sourcePath);
            List<FileInfo> fileToReturn = new List<FileInfo>();
            List<FileInfo> fileToSendFirst = new List<FileInfo>();
            List<string> exts = extensions.Split(",").ToList();
            foreach (FileInfo file in files)
            {
                foreach (string ext in exts)
                {
                    string fileExt = file.Name.Split('.').Last();
                    if (fileExt.Equals(ext))
                    {
                        fileToSendFirst.Add(file);
                        files.Remove(file);
                    }
                }
            }
            fileToReturn.AddRange(fileToSendFirst);
            fileToReturn.AddRange(files);

            return fileToReturn;
        }


        public void ThreadSleep(bool pause/*, Thread thread*/)
        {

            while (pause)
            {
                Thread.Sleep(2000);
            }

        }

        public void ThreadPause(bool pause)
        {
            ThreadSleep(pause);
        }

        public ObservableCollection<Saves> getSaves()
        {
            string fileName = "..\\..\\..\\Saves\\AllSaves.json";
            ObservableCollection<Saves> allSaves = new ObservableCollection<Saves>();
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                string[] lines = jsonString.Split('\n');
                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        Saves mySave = JsonSerializer.Deserialize<Saves>(line);
                        allSaves.Add(mySave);
                    }
                }

            }
            else
            {
                File.Create(fileName);

            }
            return allSaves;
        }
        public configModel GetConfig()
        {
            string fileName = "..\\..\\..\\Saves\\Config.json";
            configModel config = new configModel();
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                if (jsonString != "")
                {
                    config = JsonSerializer.Deserialize<configModel>(jsonString);
                }
            }
            else
            {
                File.Create(fileName);
            }

            return config;
        }
        public void SaveConfig(string language, string businessSoftware)
        {
            var config = new configModel()
            {
                language = language,
                businessSoftware = businessSoftware
            };

            string jsonString = JsonSerializer.Serialize(config);
            string fileName = "..\\..\\..\\Saves\\Config.json";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                File.AppendAllText(fileName, jsonString);

            }
            else
            {
                File.Create(fileName);
                File.AppendAllText(fileName, jsonString);
            }
        }

        // TODO : Mallory - Modifier la méthode pour qu'elle prenne en compte le logiciel métier indiqué par l'utilisateur (changer le if)
        /// <summary>
        /// detectBusinessSoftware is a method used by the application to detect if the business software indicated by the user in the options...
        /// is currently running or not. If it is, the thread executing detectBusinessSoftware will be put to sleep for 1 second.
        /// </summary>
        public void detectBusinessSoftware()
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "CalculatorApp")
                {
                    Thread.Sleep(1000);
                    // Recursively calling the method to make sure if the business software is still running or not
                    detectBusinessSoftware();
                }
            }
        }
    }
}