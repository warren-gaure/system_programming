using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LivrableMVVM.View
{
    /// <summary>
    /// Logique d'interaction pour Options.xaml
    /// </summary>
    public partial class Options : System.Windows.Controls.UserControl
    {
        public Options()
        {
            InitializeComponent();
        }

        public void OnFolderclicked(object sender, RoutedEventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                fbd.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    this.Metier.Text = fbd.FileName;
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
