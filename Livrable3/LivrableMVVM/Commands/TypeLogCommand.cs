using Livrable3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livrable3.Commands
{
    internal class TypeLogCommand : CommandBase
    {
        ExecuteViewModel _mvm;
        public TypeLogCommand(ExecuteViewModel mvm)
        {
            _mvm = mvm;
        }
        public override void Execute(object? parameter)
        {
            _mvm.TypeLog = (string)parameter;
        }
    }
}