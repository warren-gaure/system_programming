using LivrableMVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LivrableMVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase? CurrentViewModel { get; set; }

        public ICommand HomeViewCommand { get; }
        public ICommand CreateViewCommand { get; }
        public ICommand ExecuteViewCommand { get; }
        public ICommand OptionViewCommand { get; }
        public MainViewModel() 
        { 
            CreateViewCommand = new CreateViewBindCommand(this);
            ExecuteViewCommand = new ExecuteViewBindCommand(this);
            OptionViewCommand = new OptionViewBindCommand(this);

            CurrentViewModel = new ViewModelBase();
        }

        
    }
}
