using ExternalConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalConsole.Command
{
    internal class PlayCommand : CommandBase
    {

        private ViewModel.ViewModel _evm;

        public PlayCommand(ViewModel.ViewModel evm)
        {
            _evm = evm;
        }

        public override void Execute(object? parameter)
        {
            if(_evm.SelectedItem != null) Communication.SetSave(new string[]{ _evm.SelectedItem.Name }, 1);
        }
    }
}
