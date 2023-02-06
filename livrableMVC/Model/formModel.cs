using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.Model
{
    internal class formModel
    {
        public int left = 0;
        public int top = 0;
        public List<QuestionModel> questions = new List<QuestionModel>();

        public formModel(int left, int top) 
        {
            this.left = left;
            this.top = top;
        }

        public formModel(QuestionModel question, int left, int top)
        {
            questions.Add(question);
            this.left = left;
            this.top = top;
        }

        public formModel(IEnumerable<QuestionModel> questions)
        {
            foreach(QuestionModel question in questions)
            {
                this.questions.Add(question);
            }
        }

        public void AddQuestion(QuestionModel question) { questions.Add(question); }

        public void AddQuestion(string question) { questions.Add(new QuestionModel(question)); }

        public void AddQuestions(IEnumerable<QuestionModel> questions)
        {
            foreach(QuestionModel question in questions)
            {
                this.questions.Add(question);
            }
        }

        public void AddQuestions(IEnumerable<string> questions)
        {
            foreach (string question in questions)
            {
                this.questions.Add(new QuestionModel(question));
            }
        }

        public void RemoveQuestion(QuestionModel question)
        {
            questions.Remove(question);
        }

    }
}
