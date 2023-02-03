using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livrable1.view
{
    internal class SaveModel
    {
        string name;
        string source;
        string target;
        int method;
        public void saveModel(string name, string source, string target, int methode) { 
            this.name = name;
            this.source = source;
            this.target = target;
            this.method = methode;
        }
    }
}
