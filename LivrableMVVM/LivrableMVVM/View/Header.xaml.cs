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
    /// Logique d'interaction pour Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent HomeClickedEvent = EventManager.RegisterRoutedEvent("HomeClickedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Header));
        public static readonly RoutedEvent CreateClickedEvent = EventManager.RegisterRoutedEvent("CreateClickedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Header));
        
        public event RoutedEventHandler HomeClicked
        {
            add { AddHandler(HomeClickedEvent, value);  }
            remove { RemoveHandler(HomeClickedEvent, value); }
        }

        public event RoutedEventHandler CreateClicked
        {
            add { AddHandler(CreateClickedEvent, value); }
            remove { RemoveHandler(CreateClickedEvent, value); }
        }

        private void OnHomeClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Header.HomeClickedEvent));
        }

        private void OnCreateClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Header.CreateClickedEvent));
        }


    }
}
