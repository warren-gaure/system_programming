using livrableMVVM.Model;
using LivrableMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrableMVVM.Commands
{
    internal class ExecuteSavesCommand : CommandBase
    {
        private ExecuteViewModel _evm;

        public ExecuteSavesCommand(ExecuteViewModel evm)
        {
            _evm= evm;
        }
        public override void Execute(object? parameter)
        {
           SaveModel saveModel = new SaveModel();
           saveModel.executeSave(_evm.SelectedItem);
        }
    }
}
