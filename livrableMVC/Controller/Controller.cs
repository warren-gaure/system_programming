using livrableMVC.Model;
using livrableMVC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.ControllerSpace
{
    internal class Controller
    {
        public LanguageModel langModel { get; set; }
        public SaveModel saveModel { get; set; }
        public LanguageView langView { get; set; }
        public ConsoleView conView { get; set; }

        public Controller() 
        { 
            saveModel = new SaveModel();
            langModel = new LanguageModel();
            langView = new LanguageView();
            consoleView = new ConsoleView();
        }
        public void start()
        {






        }

        public void translateApp(string language)
        {
            langModel.getTranslations()
        }
        
        public void addSave()
        {

        }



    }

}