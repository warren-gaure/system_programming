using Livrable3.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Livrable3.ViewModel
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
