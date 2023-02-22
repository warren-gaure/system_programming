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
        public ICommand SaveConfigCommand { get; }

        private SaveModel _saveModel;

        public OptionViewModel()
        {
            SaveConfigCommand = new SaveConfigCommand(this);
            _saveModel = new SaveModel();
            var conf = _saveModel.GetConfig();
            _selectedItem = conf.language;
            _businessSoftware= conf.businessSoftware;
            _languages = new ObservableCollection<string>();
            _languages.Add(new string("English"));
            _languages.Add(new string("Français"));
            
            
        }

    }
}
