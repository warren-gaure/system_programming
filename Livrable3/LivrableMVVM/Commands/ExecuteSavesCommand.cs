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

                
           

                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(10000);
                    modelSave.detectBusinessSoftware(bSoft);
                    var sw = new Stopwatch();
                    sw.Start();
                    if (_evm.SelectedItem.cryptage != null)
                    {
                        string[] AllCryptExt = _evm.SelectedItem.cryptage.Split(",");
                        modelSave.didCrypto(AllCryptExt, _evm.SelectedItem.sourceTarget, 2048);
                    }

                    List<FileInfo> fileInfos = modelSave.ParamSend(_evm.SelectedItem.sourceTarget, _evm.SelectedItem.prioFiles);

                    //Copy all files
                    Saves execSave = modelSave.executeSave(_evm.SelectedItem, fileInfos, _evm.TypeLog, bSoft);

                    sw.Stop();
                    long time = sw.ElapsedMilliseconds;

                    //Daily logs
                    if (_evm.TypeLog == "JSON")
                    {
                        dailyLogsModel.DailyLogsFunction(execSave.saveName, execSave.sourceTarget, execSave.destinationTarget, modelSave.GetData()[4], time, DateTime.Now, 0);

                    }
                    else
                    {
                        dailyLogsModel.dailyLogToXML(execSave.saveName, execSave.sourceTarget, execSave.destinationTarget, modelSave.GetData()[4], time, DateTime.Now, 0);

                    }
                });
                thread.Name = _evm.SelectedItem.saveName;
                thread.Start();
                try 
                {
                    ExecuteViewModel.ThreadSleep.Add(_evm.SelectedItem.saveName,false);
                    ExecuteViewModel.ThreadAbort.Add(_evm.SelectedItem.saveName,false);
                }
                catch (Exception ex){ }



            });
        }
    }
}
