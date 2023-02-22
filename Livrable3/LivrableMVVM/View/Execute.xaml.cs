using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Livrable3.View
{
    /// <summary>
    /// Logique d'interaction pour Execute.xaml
    /// </summary>
    public partial class Execute : UserControl
    {
        public Execute()
        {
            InitializeComponent();
            AddCheckbox(new string[24]{ "test", "test2", "test3", "test4", "test5", "test6", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test" });
        }

        public void AddCheckbox(IEnumerable<string> Names)
        {
            foreach(var Name in Names)
            {
                var checkbox = new CheckBox();
                checkbox.Foreground = (Brush)(new BrushConverter().ConvertFromString("#FFFFFF"));
                checkbox.Content = Name;
                //this.Checkboxs.Children.Add(checkbox);
                
            }
        }

        public void AddCheckbox(string Name)
        {
            var checkbox = new CheckBox();
            checkbox.Foreground = (Brush)(new BrushConverter().ConvertFromString("#FFFFFF"));
            checkbox.Content= Name;
            //this.Checkboxs.Children.Add(checkbox);
            
        }

        /// <summary>
        /// En gros Checkboxs.Children return des objects donc je dois recupéré la propriété IsChecked puis ça valeur et si c'est bon je fais pareil pour le nom
        /// </summary>
        /// <returns></returns>
        public List<string> GetChecked()
        {
            var list = new List<string>();
            /*foreach(var checkbox in this.Checkboxs.Children)
            {
                var property = checkbox.GetType().GetProperty("IsChecked");
                if (property != null) 
                {
                    var v = property.GetValue(checkbox);
                    if (v != null && v.GetType() == typeof(bool))
                    {
                        if((bool)v)
                        {
                            var pName = checkbox.GetType().GetProperty("Content");
                            if(pName != null)
                            {
                                var Name = pName.GetValue(checkbox);
                                if(Name != null)
                                {
                                    list.Add((string)Name);
                                }
                            }
                        }
                    }
                }

            }*/
            return list;
        }

        public void onExecute(object sender, RoutedEventArgs e)
        {
            GetChecked();
        }

    }
}
