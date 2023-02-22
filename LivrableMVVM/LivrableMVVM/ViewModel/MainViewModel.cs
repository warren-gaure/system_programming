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
        public ViewModelBase? HomeViewModel { get; set; }
        public ViewModelBase? CreateViewModel { get; set; }
        public ViewModelBase? ExecuteViewModel { get; set; }
        public ViewModelBase? OptionViewModel { get; set; }

        public ICommand HomeViewCommand { get; }
        public ICommand CreateViewCommand { get; }
        public ICommand ExecuteViewCommand { get; }
        public ICommand OptionViewCommand { get; }
        public MainViewModel() 
        {
            
            HomeViewModel = new ViewModelBase();
            CreateViewModel = new CreateViewModel();
            ExecuteViewModel = new ExecuteViewModel();
            OptionViewModel = new OptionViewModel();
            ExecuteViewCommand = new ExecuteViewBindCommand(this);
        }

        
    }
}
