using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using livrableMVC.Controller;

namespace livrableMVC
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ControllerLanguage controller = new ControllerLanguage();
            controller.test();
        }
    }
}
