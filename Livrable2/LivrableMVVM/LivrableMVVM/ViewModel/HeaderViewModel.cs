using livrableMVVM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrableMVVM.ViewModel
{
    class HeaderViewModel : ViewModelBase
    {
        //propety for language
        private Dictionary<string, string> dictionnary;

        private string _buttonHomeTitle;
        public string ButtonHomeTitle
        {
            get
            {
                return _buttonHomeTitle;
            }
            set
            {
                _buttonHomeTitle = value;
                OnPropertyChanged(nameof(ButtonHomeTitle));
            }
        }

        private string _buttonCreateTitle;
        public string ButtonCreateTitle
        {
            get
            {
                return _buttonCreateTitle;
            }
            set
            {
                _buttonCreateTitle = value;
                OnPropertyChanged(nameof(ButtonCreateTitle));
            }
        }

        private string _buttonExecuteTitle;
        public string ButtonExecuteTitle
        {
            get
            {
                return _buttonExecuteTitle;
            }
            set
            {
                _buttonExecuteTitle = value;
                OnPropertyChanged(nameof(ButtonExecuteTitle));
            }
        }

        private string _buttonOptionTitle;
        public string ButtonOptionTitle
        {
            get
            {
                return _buttonOptionTitle;
            }
            set
            {
                _buttonOptionTitle = value;
                OnPropertyChanged(nameof(ButtonOptionTitle));
            }
        }



        private LanguageModel _languageModel;
        private SaveModel _saveModel;

        public HeaderViewModel()
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

            _buttonHomeTitle = dictionnary["homeTitle"];
            _buttonCreateTitle = dictionnary["createTitle"];
            _buttonExecuteTitle = dictionnary["executeTitle"];
            _buttonOptionTitle = dictionnary["optionTitle"];

        }
    }
}
