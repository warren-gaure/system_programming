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
        private string _typeLog;

        public string TypeLog
        {
            get
            {
                return _typeLog;
            }
            set
            {
                _typeLog = value;
                OnPropertyChanged(nameof(TypeLog));
            }
        }
        public ICommand ExecuteCommand { get; }

        public ICommand TypeLogCommand { get; set; }

        public ExecuteViewModel ()
        { 
            ExecuteCommand = new ExecuteSavesCommand ();
            TypeLogCommand = new TypeLogCommand(this);
        }
    }
}
