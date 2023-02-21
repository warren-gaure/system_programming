using LivrableMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrableMVVM.Commands
{
    internal class TypeOfTheSaveCommand : CommandBase
    {
        CreateViewModel _mvm;
        public TypeOfTheSaveCommand(CreateViewModel mvm)
        {
            _mvm = mvm;
        }
        public override void Execute(object? parameter)
        {
            _mvm.Type = (string)parameter;
        }
    }
}
