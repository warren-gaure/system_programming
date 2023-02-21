using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livrable3.Model
{
    internal interface ISubject
    {
        void Attach(IObserver observer);    // Attach an observer to the subject.
        void Detach(IObserver observer);    // Detach an observer from the subject.
        void Notify();  // Notify all observers about an event.

    }
}
