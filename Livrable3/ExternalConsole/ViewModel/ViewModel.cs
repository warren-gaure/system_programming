using ExternalConsole.Command;
using ExternalConsole.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExternalConsole.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        private ObservableCollection<Save> _saves = new ObservableCollection<Save>();

        public ObservableCollection<Save> ListSaves
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
            while (true)
            { 
                ListSaves = Save.GetSaves();
                Thread.Sleep(2000);
            }
        }

        private Save selectedItem;
        public Save SelectedItem
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

        public ICommand PlayCommand { get; set; }

        public ViewModel()
        {
            //var thread = new Thread(new ThreadStart(() => this._saves = Save.GetSaves()));
            //thread.Start();
            //_saves = Save.GetSaves();
            PlayCommand = new PlayCommand(this);
            var thread = new Thread(new ThreadStart(reloadList));
            thread.Start();
        }


    }
}
