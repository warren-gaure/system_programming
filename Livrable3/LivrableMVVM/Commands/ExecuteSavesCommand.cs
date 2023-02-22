using Livrable3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Livrable3.Model;
using System.IO;
using System.Text.Json;

namespace Livrable3.Commands
{
    internal class ExecuteSavesCommand : CommandBase
    {
        
        public ExecuteSavesCommand()
        {
            
        }

        public override void Execute(object? parameter)
        {
/*            string saves = "test";
            SaveModel modelSave = new SaveModel();
            delExecSave del = modelSave.executeSave;
            Thread newThread = new Thread(new ParameterizedThreadStart(modelSave.executeSave));
            newThread.Start(saves);*/
            string saves = "test";
            string sourcePath;
            int fileSizeMax; 
            string extensions;
            SaveModel modelSave = new SaveModel();
            string fileName = "..\\..\\..\\repoSaves\\" + saveName;
            var save = System.IO.File.ReadAllText(fileName);
            Saves? saveFromFile = JsonSerializer.Deserialize<Saves>(save);
            Thread thread = new Thread(() =>
            {
                List<FileInfo> fileInfos = modelSave.ParamSend(saveFromFile.sourceTarget, fileSizeMax, extensions);
                Saves execSave = modelSave.executeSave(saveFromFile, fileInfos);
            });

            thread.Start();
        }
    }
}
