using ExternalConsole.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            ListSaves = Save.GetSaves();
        }

        public ViewModel()
        {
            //var thread = new Thread(new ThreadStart(() => this._saves = Save.GetSaves()));
            //thread.Start();
            _saves = Save.GetSaves();
        }


    }
}
