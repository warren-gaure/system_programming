using Livrable3.Commands;
using Livrable3.Model;
using Livrable3.ViewModel;
using Livrable3.Model;
using Livrable3.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Livrable3.ViewModel
{
    public class CreateViewModel : ViewModelBase
    {
        /// <summary>
        /// name's save proprety 
        /// </summary>
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }


        private string _source;

        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                OnPropertyChanged(nameof(Source));
            }
        }

        private string _target;

        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
                OnPropertyChanged(nameof(Target));
            }
        }

        private string _extension;

        public string Extension
        {
            get
            {
                return _extension;
            }
            set
            {
                _extension = value;
                OnPropertyChanged(nameof(Extension));
            }
        }

        private string _type;

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
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

        private string _saveName;
        public string SaveName
        {
            get
            {
                return _saveName;
            }
            set
            {
                _saveName = value;
                OnPropertyChanged(nameof(SaveName));
            }
        }

        private string _sourceTitle;
        public string SourceTitle
        {
            get
            {
                return _sourceTitle;
            }
            set
            {
                _sourceTitle = value;
                OnPropertyChanged(nameof(SourceTitle));
            }
        }

        private string _destTitle;
        public string DestinationTitle
        {
            get
            {
                return _destTitle;
            }
            set
            {
                _destTitle = value;
                OnPropertyChanged(nameof(DestinationTitle));
            }
        }

        private string _cryptTitle;
        public string CryptTitle
        {
            get
            {
                return _cryptTitle;
            }
            set
            {
                _cryptTitle = value;
                OnPropertyChanged(nameof(CryptTitle));
            }
        }

        private string _typeSaveTitle;
        public string TypeSaveTitle
        {
            get
            {
                return _typeSaveTitle;
            }
            set
            {
                _typeSaveTitle = value;
                OnPropertyChanged(nameof(TypeSaveTitle));
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





        public ICommand CreateCommand { get; }
        public ICommand TypeCommand { get; set; }

        private LanguageModel _languageModel;
        private SaveModel _saveModel;


        public CreateViewModel()
        {
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

            CreateCommand = new CreateSaveCommand(this);
            TypeCommand = new TypeOfTheSaveCommand(this);

            //trad
            _title = dictionnary["createTitle"];
            _description = dictionnary["createDetails"];
            _saveName = dictionnary["name"];
            _sourceTitle = dictionnary["source"];
            _destTitle = dictionnary["target"];
            _cryptTitle = dictionnary["encryption"];
            _typeSaveTitle = dictionnary["typeOfSave"];
            _buttonTitle = dictionnary["save"];





        }

    }
}
