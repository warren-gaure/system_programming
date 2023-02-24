using Livrable3.Model;
using Livrable3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Livrable3.Commands
{
    internal class PauseSavesCommand : CommandBase
    {

        private ExecuteViewModel _evm;
        bool pause;
        
        public PauseSavesCommand(ExecuteViewModel evm)
        {
            _evm = evm;
        }
        public override void Execute(object? parameter)
        {

            string threadName = _evm.SelectedItem.saveName;
            if (ExecuteViewModel.ThreadSleep[threadName])
            {
               ExecuteViewModel.ThreadSleep[threadName] = false;
                   
            }else
            {
                ExecuteViewModel.ThreadSleep[threadName] = true;    
            }
            
        }
    }
}
