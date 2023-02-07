using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.View
{
    internal class MainView
    {
        public MainView() { }

        public int Start(int left, int top, Dictionary<string, string> sentences)
        {
            var menu = new List<QuestionModel>();
            using (var menuForm = new formModel(left, top))
            {
                menuForm.AddQuestion(new QuestionModel("Menu", new string[3] { sentences["save"], sentences["execute"], sentences["exit"] }));
                menu = menuForm.Start();
            }
            return menu[0].valueChoosed;
        }
    }
}
