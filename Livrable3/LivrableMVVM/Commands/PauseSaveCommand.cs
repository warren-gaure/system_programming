using Livrable3.Model;
using Livrable3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Livrable3.Commands
{
    internal class PauseSavesCommand : CommandBase
    {

        private ExecuteViewModel _evm;
        static int i = 0;
        bool pause;
        public PauseSavesCommand(ExecuteViewModel evm)
        {
            _evm = evm;
        }
        public override void Execute(object? parameter)
        {
            i++;
            if (i % 2 == 0)
            {
                pause = false;
            }
            else
            {
                pause = true;
            }
            SaveModel saveM = new SaveModel();
            saveM.ThreadPause(pause);
        }
    }
}
