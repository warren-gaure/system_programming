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

namespace LivrableMVVM.ViewModel
{
    internal class OptionViewModel : ViewModelBase
    {
        public ObservableCollection<string> _languages;

        public ObservableCollection<string> Languages
        {
            get
            {
                return _languages;
            }
            set
            {
                _languages = value;
                OnPropertyChanged(nameof(Languages));
            }
        }

        private string _selectedItem;

        public string SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private string _businessSoftware;

        public string BusinessSoftware
        {
            get
            {
                return _businessSoftware;
            }
            set
            {
                _businessSoftware = value;
                OnPropertyChanged(nameof(BusinessSoftware));
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

        private string _languageTitle;
        public string LanguageTitle
        {
            get
            {
                return _languageTitle;
            }
            set
            {
                _languageTitle = value;
                OnPropertyChanged(nameof(LanguageTitle));
            }
        }

        private string _businessTitle;
        public string BusinessTitle
        {
            get
            {
                return _businessTitle;
            }
            set
            {
                _languageTitle = value;
                OnPropertyChanged(nameof(BusinessTitle));
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

        public ICommand SaveConfigCommand { get; }

        private SaveModel _saveModel;
        private LanguageModel _languageModel;

        public OptionViewModel()
        {
            SaveConfigCommand = new SaveConfigCommand(this);
            _saveModel = new SaveModel();
            _languageModel= new LanguageModel();
            var conf = _saveModel.GetConfig();
            if (conf.language == "English")
            {
                dictionnary = _languageModel.languages("eng");
            }
            else
            {
                dictionnary = _languageModel.languages("");
            }
            _selectedItem = conf.language;
            _businessSoftware= conf.businessSoftware;
            _languages = new ObservableCollection<string>();
            _languages.Add(new string("English"));
            _languages.Add(new string("Français"));

            //trad
            _title = dictionnary["optionTitle"];
            _description = dictionnary["optionDetails"];
            _languageTitle = dictionnary["selectLang"];
            _businessTitle = dictionnary["businessSoftware"];
            _buttonTitle = dictionnary["save"];


        }

    }
}
