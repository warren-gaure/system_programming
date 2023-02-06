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
        public SaveView() 
        { 
            var answer = new List<QuestionModel>();
            using (var form = new formController(0, 1))
            {
                form.AddQuestions(new string[3] { "Name", "Src", "tget" });
                form.AddQuestion(new QuestionModel("Type", new string[2] { "complet", "partiel" }));
                answer = form.Start();
            }
            var save = new SaveModel(answer[0].Answer, answer[1].Answer, answer[2].Answer, answer[3].Answer);
            Console.WriteLine("réponses");
            foreach(var question in answer)
            {
                Console.WriteLine(question.Answer);
            }
        }
    }
}
