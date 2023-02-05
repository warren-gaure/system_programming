using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Livrable1.model
{
    internal class LanguageModel
    {
        Dictionary<string, string> french = new Dictionary<string, string>
        {
            { "hello" , "Bonjour et bienvenue dans votre solution de sauvegarde." }
        };
        Dictionary<string, string> english = new Dictionary<string, string>
        {
            { "hello" , "Hello, welcome in ouor solution" }
        };
        string sentences = "";

        public string languages( string lang, string keys)
        {
            if (lang.Equals("ang"))
            {
                sentences = english[keys];
            }
            else if (lang.Equals( "fr"))
            {
                sentences = french[keys];
            }
            else
            {
                sentences= "Error, no lnaguage value found ";
            }

            return sentences;
        }
    }
}
