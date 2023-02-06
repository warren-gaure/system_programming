using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrableMVC.Model
{
    internal class SaveModel
    {
        string name;
        string source;
        string target;
        string method;
        public SaveModel(string name, string source, string target, string methode)
        {
            this.name = name;
            this.source = source;
            this.target = target;
            this.method = methode;
        }
        public List<string> saveInformation()
        {
            List<string> saveModel = new List<string>();
            saveModel.Add(this.name);
            saveModel.Add(this.source);
            saveModel.Add(this.target);
            saveModel.Add(this.method);
            return saveModel;
        }
    }
}
