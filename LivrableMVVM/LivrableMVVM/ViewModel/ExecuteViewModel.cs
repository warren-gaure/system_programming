using LivrableMVVM.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private readonly ObservableCollection<CheckBox> _saves;

        public IEnumerable<CheckBox> Saves => _saves;

        private ObservableCollection<CheckBox> _selectedItems;

        public ObservableCollection<CheckBox> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                OnPropertyChanged(nameof(SelectedItems));
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

        

        

        private bool _isChecked;

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }


        public ICommand ExecuteCommand { get; }

        public ICommand TypeLogCommand { get; set; }

        public ExecuteViewModel ()
        { 
            ExecuteCommand = new ExecuteSavesCommand ();
            TypeLogCommand = new TypeLogCommand(this);

            //get all projectSaves and display them into the view
            _saves= new ObservableCollection<CheckBox> ();
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves.Add(new CheckBox());
            _saves[0].Content = "test1";
            _saves[1].Content = "test2";
            _saves[2].Content = "test3";
            _saves[3].Content = "test4";
            _saves[4].Content = "test5";
            _saves[5].Content = "test6";
            _saves[6].Content = "test7";
            _saves[7].Content = "test8";
            _saves[8].Content = "test9";
            _saves[9].Content = "test10";
            _saves[10].Content = "test11";
            _saves[11].Content = "test12";
            _saves[12].Content = "test13";
            _saves[13].Content = "test14";
            _saves[14].Content = "test15";
            _saves[15].Content = "test16";

        }
    }
}
