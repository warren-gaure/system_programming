using LivrableMVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LivrableMVVM.ViewModel
{
    public class ExecuteViewModel : ViewModelBase
    {
        public ICommand ExecuteCommand { get; }

        public ExecuteViewModel ()
        { 
            ExecuteCommand = new ExecuteSavesCommand ();
        }
    }
}
