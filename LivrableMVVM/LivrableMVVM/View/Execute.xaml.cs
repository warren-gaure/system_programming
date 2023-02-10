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

namespace LivrableMVVM.View
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
                checkbox.Content = Name;
                this.Checkboxs.Children.Add(checkbox);
            }
        }

        public void AddCheckbox(string Name)
        {
            var checkbox = new CheckBox();
            checkbox.Content= Name;
            this.Checkboxs.Children.Add(checkbox);
        }
    }
}
