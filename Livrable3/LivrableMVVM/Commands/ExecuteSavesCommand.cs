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
using System.Diagnostics;

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
            if (_evm.SelectedItem != null) { 
            DailyLogs dailyLogsModel = new DailyLogs();
            //InstantLogs instantLogsModel = new InstantLogs();
            SaveModel modelSave = new SaveModel();
            string extensions = "";
           
            Thread thread = new Thread(() =>
            {
                
                var sw = new Stopwatch();
                sw.Start();
                List<FileInfo> fileInfos = modelSave.ParamSend(_evm.SelectedItem.sourceTarget, extensions);
                Saves execSave = modelSave.executeSave(_evm.SelectedItem, fileInfos, _evm.TypeLog);
                sw.Stop();
                long time = sw.ElapsedMilliseconds;
                if (_evm.TypeLog == "JSON")
                {
                    dailyLogsModel.DailyLogsFunction(execSave.saveName, execSave.sourceTarget, execSave.destinationTarget, modelSave.GetData()[4], time, DateTime.Now, 0);

                }
                else
                {
                    dailyLogsModel.dailyLogToXML(execSave.saveName, execSave.sourceTarget, execSave.destinationTarget, modelSave.GetData()[4], time, DateTime.Now, 0);

                }


            });

            thread.Start();

            }
        }
    }
}
