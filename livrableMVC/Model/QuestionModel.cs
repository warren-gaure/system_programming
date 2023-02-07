using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.Model
{
    internal class QuestionModel
    {
        public string Text = "";
        public string Answer { get; set; } = "";
        public List<string> Answers = new List<string>();
        public int valueChoosed = -1;
        public QuestionModel(string text) 
        {
            Text = text;
        }

        public QuestionModel(string text, IEnumerable<string> answers) 
        {
            Text = text;
            foreach(var answer in answers)
            {
                Answers.Add(answer);
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
