using Livrable3.Model;
using Livrable3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livrable3.Commands
{
    internal class SaveConfigCommand : CommandBase
    {
        OptionViewModel _ovm;
        public SaveConfigCommand(OptionViewModel ovm)
        {
            _ovm = ovm;
        }
        public override void Execute(object? parameter)
        {
            SaveModel temp = new SaveModel();
            temp.SaveConfig(_ovm.SelectedItem, _ovm.BusinessSoftware);
        }
    }
}
