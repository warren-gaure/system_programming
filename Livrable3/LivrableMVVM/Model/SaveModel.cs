using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            Process businessSoftware = new Process();
            businessSoftware.StartInfo.FileName = "calc.exe";
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
        /// Copy all modified file or new file from sourceDirectory to targetDirectory
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        private void CopyDirectory(List<FileInfo> files, string targetDirectory)
        {
            DirectoryInfo target = new DirectoryInfo(targetDirectory);
            foreach (FileInfo file in files)
            {
                Notify();
                file.CopyTo(System.IO.Path.Combine(target.FullName, file.Name), true);
                filesDone++;
                Notify();
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
            foreach(string ext  in extension)
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
        public List<FileInfo> ParamSend(string sourcePath, int fileSizeMax, string extensions)
        {
            List<FileInfo> files = nav(sourcePath);
            List<FileInfo> fileToSend= new List<FileInfo>();
            List<FileInfo> fileToReturn = new List<FileInfo>();
            List<FileInfo> fileToSendFirst = new List<FileInfo>();
            List<string> exts = extensions.Split(",").ToList();
            foreach (FileInfo file in files)
            {
                if (file.Length > fileSizeMax)
                {
                    fileToSend.Add(file);
                }
            }
            foreach(FileInfo file in fileToSend)
            {
                foreach(string ext in exts)
                {
                    string fileExt = file.Name.Split('.').Last();
                    if (fileExt.Equals(ext))
                    {
                        fileToSendFirst.Add(file);
                        fileToSend.Remove(file);
                    }
                }
            }
            fileToReturn.AddRange(fileToSendFirst);
            fileToReturn.AddRange(fileToSend);

            return fileToReturn;
        }
        public void threadPause()
        {
            //ici
        }
    }
}
