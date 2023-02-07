﻿using livrableMVC.ControllerSpace;
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
                    string? answer = " ";
                    answer = Console.ReadLine();
                    if (!string.IsNullOrEmpty(answer))
                    {
                        model.questions[i].Answer = answer;
                    }
                }
                else
                {
                    using (var menu = new MenuModel(0 + model.left, i * 2 + 1 + model.top))
                    {
                        foreach (var Answer in model.questions[i].Answers)
                        {
                            menu.AddItem(Answer);
                        }
                        model.questions[i].valueChoosed = menu.Start();
                        model.questions[i].Answer = model.questions[i].Answers[model.questions[i].valueChoosed];
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
