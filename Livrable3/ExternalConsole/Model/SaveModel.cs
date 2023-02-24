using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalConsole.Model
{
    public class Save
    {
        public string Name { get; set; }
        public int State { get; set; } // 0 => stopped, 1 => running, 2 paused
        public int Percent { get; set; }


        public Save(string name, int state = 0, int percent = 0)
        {
            Name = name;
            State = state;
            if (percent >= 0 && percent <= 100) {
                Percent = percent;
            }
        }

        public static ObservableCollection<Save> GetSaves()
        {
            var saves = new ObservableCollection<Save>();
            saves = Communication.Start(saves);
            return saves;
        }

    }
}
