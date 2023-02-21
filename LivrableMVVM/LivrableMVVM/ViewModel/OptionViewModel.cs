using LivrableMVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LivrableMVVM.ViewModel
{
    internal class OptionViewModel : ViewModelBase
    {
        private ComboBox _language;

        private string languageChose { get; set; }
        public ComboBox Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                
                OnPropertyChanged(nameof(Language));
                languageChose = _language.Text;
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
        public ICommand SaveConfigCommand { get; }

        public OptionViewModel()
        {
            SaveConfigCommand = new SaveConfigCommand();
        }

    }
}
