using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using livrableMVC.ControllerSpace;

namespace livrableMVC
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.start();
        }
    }
}
