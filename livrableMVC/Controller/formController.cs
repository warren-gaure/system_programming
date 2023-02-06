using livrableMVC.Model;
using livrableMVC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.ControllerSpace
{
    internal class formController : IDisposable
    {
        private formModel model;
        private formView view;
        public formController(int left, int top) 
        {
            model = new formModel(left, top);
            view = new formView(model);
        }

        public List<QuestionModel> Start()
        {
            view.Render();
            return model.questions;
        }

        public void Dispose()
        {
            view.Dispose();
        }

        public void AddQuestion(QuestionModel question) { model.AddQuestion(question); }

        public void AddQuestion(string question) { model.AddQuestion(question); }

        public void AddQuestions(IEnumerable<QuestionModel> questions) { model.AddQuestions(questions); }

        public void AddQuestions(IEnumerable<string> questions) { model.AddQuestions(questions); }

        public void RemoveQuestion(QuestionModel question) { model.RemoveQuestion(question); }

    }
}
