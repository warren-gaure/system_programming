using LivrableMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrableMVVM.Commands
{
    internal class OptionViewBindCommand : CommandBase
    {
        MainViewModel _mvm;
        public OptionViewBindCommand(MainViewModel mvm)
        {
            _mvm = mvm;
        }
        public override void Execute(object? parameter)
        {
            _mvm.CurrentViewModel = new OptionViewModel();
        }
    }
}
