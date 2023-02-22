using livrableMVVM.Model;
using LivrableMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrableMVVM.Commands
{
    internal class CreateSaveCommand : CommandBase
    {
        CreateViewModel _cvm;
        public CreateSaveCommand(CreateViewModel cvm)
        {
            _cvm = cvm;
        }
        public override void Execute(object? parameter)
        {
            SaveModel temp = new SaveModel();
            temp.createNewSave(_cvm.Source,_cvm.Target,_cvm.Type,_cvm.Name, _cvm.Extension);
        }

    }
}
