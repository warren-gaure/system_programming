using livrableMVC.ControllerSpace;
using livrableMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.View
{
    internal class formView : IDisposable
    {
        formModel model;
        public formView(formModel model) 
        {
            this.model = model;
        }

        public void Render() 
        {
            for(int i = 0; i < model.questions.Count; i++)
            {
                Console.WriteLine(model.questions[i]);
                if (model.questions[i].Answers.Count == 0) 
                {
                    string? answer = "";
                    var temp = Console.ReadLine();
                    if(temp != null)
                    {
                        answer = temp;
                    }
                    if(!string.IsNullOrEmpty(answer) )
                    {
                        model.questions[i].Answer = answer;
                    }
                }
                else
                {
                    using (var menu = new MenuController(0 + model.left, i * 2 + 1 + model.top))
                    {
                        foreach (var Answer in model.questions[i].Answers)
                        {
                            menu.AddItem(Answer);
                        }
                        model.questions[i].Answer = model.questions[i].Answers[menu.Start()];
                    }
                    Console.WriteLine(model.questions[i].Answer);
                }
            }

        }

        public void Dispose() //TODO
        {
            Console.Clear();
        }

    }
}
