using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.Model
{   
    public class FileModel
    {
        public List<string> fileList = new List<string>();
        public FileInfo[] FileInFolder;
        public string repoSaves = "../../../repoSaves";

        public List<string> FileList(string RepoSource)
        {
            DirectoryInfo dir = new DirectoryInfo(RepoSource);
            FileInFolder = dir.GetFiles();

            foreach (var file in FileInFolder)
            {
                fileList.Add(file.Name);
            }
            return fileList;
        }

        public List<string> getSaves()
        {
            fileList = new List<string>();
            string dirSaves = @"..\\..\\..\\repoSaves"; // If directory does not exist, create it.
            if (!Directory.Exists(dirSaves))
            {
                Directory.CreateDirectory(dirSaves);
            }
            DirectoryInfo dir = new DirectoryInfo(repoSaves);
            FileInFolder = dir.GetFiles();
            foreach (var file in FileInFolder)
            {
                fileList.Add(file.Name);
            }
            return fileList;
        }
    }


}
