using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.View
{
    internal class LanguageView
    {
        LanguageModel lang = new LanguageModel();
        public LanguageView() { }
        
        public string Start(Dictionary<string, string> sentences)
        {
            Console.WriteLine("         \r\n██████╗ ██████╗  ██████╗ ███████╗ ██████╗ ███████╗████████╗\r\n██╔══██╗██╔══██╗██╔═══██╗██╔════╝██╔═══██╗██╔════╝╚══██╔══╝\r\n██████╔╝██████╔╝██║   ██║███████╗██║   ██║█████╗     ██║   \r\n██╔═══╝ ██╔══██╗██║   ██║╚════██║██║   ██║██╔══╝     ██║   \r\n██║     ██║  ██║╚██████╔╝███████║╚██████╔╝██║        ██║   \r\n╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚══════╝ ╚═════╝ ╚═╝        ╚═╝   ");
            var langRes = new List<QuestionModel>();
            using (var lngform = new formModel(0, 7))
            {
                lngform.AddQuestion(new QuestionModel("Select language", new string[2] { sentences["english"], sentences["french"] }));
                langRes = lngform.Start();
            }
            if(langRes[0].valueChoosed == 1) { return "fr"; }
            else { return "eng"; }
        }
    }
}
