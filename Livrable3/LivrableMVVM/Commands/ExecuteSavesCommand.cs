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
        private string bSoft;

        public ExecuteSavesCommand(ExecuteViewModel evm,string bSoftware)
        {
            _evm = evm;
            bSoft= bSoftware;
        }

        public override void Execute(object? parameter)
        {
            if (_evm.SelectedItem != null) { 
            DailyLogs dailyLogsModel = new DailyLogs();
            SaveModel modelSave = new SaveModel();
            modelSave.detectBusinessSoftware(bSoft);
            string extensions = "";
           
            Thread thread = new Thread(() =>
            {
                
                var sw = new Stopwatch();
                sw.Start();
                string[] AllCryptExt = _evm.SelectedItem.cryptage.Split(",");
                modelSave.didCrypto(AllCryptExt, _evm.SelectedItem.sourceTarget, 2048);
                List<FileInfo> fileInfos = modelSave.ParamSend(_evm.SelectedItem.sourceTarget, extensions);
                Saves execSave = modelSave.executeSave(_evm.SelectedItem, fileInfos, _evm.TypeLog, bSoft);
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
