using livrableMVVM.Model;
using LivrableMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrableMVVM.Commands
{
    internal class ExecuteSavesCommand : CommandBase
    {
        private ExecuteViewModel _evm;
        private Saves saveAfterExecute;

        public ExecuteSavesCommand(ExecuteViewModel evm)
        {
            _evm= evm;
        }
        public override void Execute(object? parameter)
        {
           SaveModel saveModel = new SaveModel();
           DailyLogs dailyLogs= new DailyLogs();
            var sw = new Stopwatch();
            sw.Start();
            saveAfterExecute = saveModel.executeSave(_evm.SelectedItem);
            sw.Stop();
            long time = sw.ElapsedMilliseconds;
            if (_evm.TypeLog == "JSON")
            {
                dailyLogs.DailyLogsFunction(saveAfterExecute.saveName, saveAfterExecute.sourceTarget, saveAfterExecute.destinationTarget, saveModel.GetData()[4], time, DateTime.Now, 0);

            }else
            {
                dailyLogs.dailyLogToXML(saveAfterExecute.saveName, saveAfterExecute.sourceTarget, saveAfterExecute.destinationTarget, saveModel.GetData()[4], time, DateTime.Now, 0);

            }




        }
    }
}
