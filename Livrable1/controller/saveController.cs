using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livrable1.view;
using Livrable1.model;
using System.Net.Security;

namespace Livrable1.controller
{
    public class SaveController
    {
        SaveView view = new SaveView();
        LanguageModel lang = new LanguageModel();
        Dictionary<string, string> sentences = new Dictionary<string, string>();

       public void test()
        {
            sentences = lang.languages("ang");
            Console.WriteLine(sentences["hello"]);
        }


    }
}
