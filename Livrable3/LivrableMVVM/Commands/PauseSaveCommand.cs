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
        static int i = 0;
        bool pause;
        public PauseSavesCommand(ExecuteViewModel evm)
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
                    if (_evm.ThreadSleep[_evm.SelectedItem.saveName])
                    {
                        _evm.ThreadSleep[_evm.SelectedItem.saveName] = false;
                        t.Start();
                    }
                    else
                    {

                        _evm.ThreadSleep[_evm.SelectedItem.saveName] = true;
                        t.Suspend();
                    }
                    
                }
            }
        }
    }
}
