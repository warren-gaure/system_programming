using Livrable3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Livrable3.Model;

namespace Livrable3.Commands
{
    internal class ExecuteSavesCommand : CommandBase
    {
        
        public ExecuteSavesCommand()
        {
            
        }

        public delegate Saves delExecSave(string saveName);

        public override void Execute(object? parameter)
        {
/*            SaveModel modelSave = new SaveModel();
            delExecSave del = modelSave.executeSave;
            Thread newThread = new Thread(new ParameterizedThreadStart(del.Invoke));
            newThread.Start("plop");*/
        }
    }
}
