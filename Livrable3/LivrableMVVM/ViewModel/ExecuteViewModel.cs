using Livrable3.Commands;
using Livrable3.Model;
using Livrable3.ViewModel;
using Livrable3.Model;
using Livrable3.Commands;
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
using System.Threading;

namespace Livrable3.ViewModel
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

        private Saves selectedItem;

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

        private string _buttonPause;
        public string ButtonPause
        {
            get
            {
                return _buttonPause;
            }
            set
            {
                _buttonPause = value;
                OnPropertyChanged(nameof(ButtonPause));
            }
        }

        private string _buttonStop;
        public string ButtonStop
        {
            get
            {
                return _buttonStop;
            }
            set
            {
                _buttonStop = value;
                OnPropertyChanged(nameof(ButtonStop));
            }
        }
        private bool _buttonEnabled;
        public bool ButtonEnabled
        {
            get
            {
                
                return _buttonEnabled;
            }
            set
            {
                
                _buttonEnabled = value;

                OnPropertyChanged(nameof(ButtonEnabled));
            }
        }

        public ICommand ExecuteCommand { get; set; }
        public ICommand PauseCommand { get; set; }
        public ICommand StopCommand { get; set; }

        public ICommand TypeLogCommand { get; set; }

        private SaveModel _saveModel;
        private LanguageModel _languageModel;
        public List<Thread> allThread;
        public Dictionary<string, bool> ThreadSleep;
        public ExecuteViewModel()
        {

            TypeLogCommand = new TypeLogCommand(this);
            allThread= new List<Thread>();
            ThreadSleep = new Dictionary<string, bool>();
        //get all projectSaves and display them into the view
        _saveModel = new SaveModel();
            _languageModel = new LanguageModel();
            var conf = _saveModel.GetConfig();

            if (conf.language == "English")
            {
                dictionnary = _languageModel.languages("eng");
            }
            else
            {
                dictionnary = _languageModel.languages("");
            }
            _saves = _saveModel.getSaves();
            _buttonEnabled = true;

            //trad
            _title = dictionnary["executeTitle"];
            _description = dictionnary["executeDetails"];
            _typeLogTitle = dictionnary["typeOfLog"];
            _buttonTitle = dictionnary["execute"];
            _buttonPause = dictionnary["pause"];
            _buttonStop = dictionnary["stop"];
            
            ExecuteCommand = new ExecuteSavesCommand(this,conf.businessSoftware);
            
            PauseCommand = new PauseSavesCommand(this);
            StopCommand = new StopSavesCommand(this);
        }
    }
}
