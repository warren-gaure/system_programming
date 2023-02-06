using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.ControllerSpace
{
    internal class Controller
    {
  
        LanguageModel lang = new LanguageModel();
        Dictionary<string, string> sentences = new Dictionary<string, string>();

        public void test()
        {
            sentences = lang.languages("ang");
            Console.WriteLine(sentences["hello"]);
            var res = new List<QuestionModel>();
            using (var form = new formController(0, 1))
            {
                form.AddQuestion("question1");
                form.AddQuestion(new QuestionModel("question2", new string[2]{"reponse1", "reponse2"} ));
                form.AddQuestions(new string[] { "question3", "question4" });
                res = form.Start();
            }
            Console.WriteLine("Réponses");
            foreach(var question in res)
            {
                Console.WriteLine(question.Answer);
            }
        }
    }

}