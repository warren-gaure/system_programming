using LivrableMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrableMVVM.Commands
{
    internal class ExecuteViewBindCommand : CommandBase
    {
        MainViewModel _evm;
        public ExecuteViewBindCommand(MainViewModel evm)
        {
            _evm = evm;
        }
        public override void Execute(object? parameter)
        {
            
        }
    }
}
