using livrableMVVM.Model;
using LivrableMVVM.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace LivrableMVVM.ViewModel
{
    public class ExecuteViewModel : ViewModelBase
    {
        public ObservableCollection<Saves> _saves = new ObservableCollection<Saves>();

        public ObservableCollection<Saves> ListSaves
        {
            get
            {
                return _saves;
            }
            set
            {
                _saves = value;
                OnPropertyChanged(nameof(ListSaves));
            }
        }
        public void reloadList()
        {
            ListSaves = _saveModel.getSaves();
        }

        private Saves selectedItem = new Saves();

        public Saves SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }


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

        private SaveModel _saveModel;

        public ExecuteViewModel ()
        { 
            ExecuteCommand = new ExecuteSavesCommand ();
            TypeLogCommand = new TypeLogCommand(this);

            //get all projectSaves and display them into the view
            _saveModel = new SaveModel();
            _saves = _saveModel.getSaves();

        }
    }
}
