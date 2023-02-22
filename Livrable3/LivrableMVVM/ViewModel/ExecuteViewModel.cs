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

        private string[] _saves;
        public string[] Saves
        {
            get
            {
                return _saves;
            }
            set
            {
                _saves = value;
                OnPropertyChanged(nameof(Saves));
            }
        }

        public ICommand ExecuteCommand { get; }

        public ICommand TypeLogCommand { get; set; }

        public ExecuteViewModel()
        {
            ExecuteCommand = new ExecuteSavesCommand();
            TypeLogCommand = new TypeLogCommand(this);
        }
    }
}
