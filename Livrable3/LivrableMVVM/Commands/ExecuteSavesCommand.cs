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

        private ExecuteViewModel _evm;

        public ExecuteSavesCommand(ExecuteViewModel evm)
        {
            _evm = evm;
        }

        public override void Execute(object? parameter)
        {
            SaveModel saveModel = new SaveModel();
            DailyLogs dailyLogsModel = new DailyLogs();
            SaveModel modelSave = new SaveModel();
            string extensions = "";
           
            Thread thread = new Thread(() =>
            {
                List<FileInfo> fileInfos = modelSave.ParamSend(_evm.SelectedItem.sourceTarget, extensions);
                Saves execSave = modelSave.executeSave(_evm.SelectedItem, fileInfos);
            });

            thread.Start();
        }
    }
}
