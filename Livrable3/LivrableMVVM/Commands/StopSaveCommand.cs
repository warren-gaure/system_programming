using Livrable3.Model;
using Livrable3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Livrable3.Commands
{
    internal class StopSavesCommand : CommandBase
    {

        private ExecuteViewModel _evm;

        public StopSavesCommand(ExecuteViewModel evm)
        {
            _evm = evm;
        }

        public override void Execute(object? parameter)
        {
            List<Thread> thread = _evm.allThread;
          
            foreach (Thread t in thread)
            {
                if (t.Name == _evm.SelectedItem.saveName)
                {
                  
                    t.Abort();
                    
                    _evm.allThread.Remove(t);
                    _evm.ThreadSleep.Remove(t.Name);
                }
            }
           

        }
    }
}
