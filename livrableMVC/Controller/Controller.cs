using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.Controller
{
    internal class ControllerSolution
    {
  
        LanguageModel lang = new LanguageModel();
        Dictionary<string, string> sentences = new Dictionary<string, string>();

        public void test()
        {
            sentences = lang.languages("ang");
            Console.WriteLine(sentences["hello"]);
        }


    }

}