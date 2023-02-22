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

        //propety for language

        private Dictionary<string, string> dictionnary;

        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _typeLogTitle;
        public string TypeLogTitle
        {
            get
            {
                return _typeLogTitle;
            }
            set
            {
                _typeLogTitle = value;
                OnPropertyChanged(nameof(TypeLogTitle));
            }
        }

        private string _buttonTitle;
        public string ButtonTitle
        {
            get
            {
                return _buttonTitle;
            }
            set
            {
                _buttonTitle = value;
                OnPropertyChanged(nameof(ButtonTitle));
            }
        }




        public ICommand ExecuteCommand { get; }

        public ICommand TypeLogCommand { get; set; }

        private SaveModel _saveModel;
        private LanguageModel _languageModel;

        public ExecuteViewModel ()
        { 
            ExecuteCommand = new ExecuteSavesCommand ();
            TypeLogCommand = new TypeLogCommand(this);

            //get all projectSaves and display them into the view
            _saveModel = new SaveModel();
            _languageModel = new LanguageModel();
            dictionnary = _languageModel.languages("");
            var conf = _saveModel.GetConfig();
            _saves = _saveModel.getSaves();

            //trad
            _title = dictionnary["executeTitle"];
            _description = dictionnary["executeDetails"];
            _typeLogTitle = dictionnary["typeOfLog"];
            _buttonTitle = dictionnary["execute"];


        }
    }
}
