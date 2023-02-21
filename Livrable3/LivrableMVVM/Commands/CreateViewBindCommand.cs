using Livrable3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livrable3.Commands
{
    internal class CreateViewBindCommand : CommandBase
    {
        MainViewModel _mvm;
        public CreateViewBindCommand(MainViewModel mvm) 
        { 
            _mvm= mvm;
        }
        public override void Execute(object? parameter)
        {
            
        }
    }
}
