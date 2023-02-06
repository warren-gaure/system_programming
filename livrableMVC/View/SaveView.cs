using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using livrableMVC.ControllerSpace;
using livrableMVC.Model;

namespace livrableMVC.View
{
    internal class SaveView
    {
        public SaveView() { }

        public List<string> Start()
        {
            var answer = new List<QuestionModel>();
            using (var form = new formModel(0, 4))
            {
                form.AddQuestions(new string[3] { "Name", "Src", "tget" });
                form.AddQuestion(new QuestionModel("Type", new string[2] { "complet", "partiel" }));
                answer = form.Start();
            }
            return new List<string> { answer[0].Answer, answer[1].Answer, answer[2].Answer, answer[3].Answer };
        }

    }
}
