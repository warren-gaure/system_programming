using LivrableMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.Model
{
    internal interface IObserver
    {
        void Update(ISubject subject);        // Receive update from subject
    }
}
