using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LivrableMVVM.ViewModel
{
    public class CreateViewModel : ViewModelBase
    {
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

        public ICommand CreateCommand { get; }

        public CreateViewModel() 
        { 
        
        }

    }
}
