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
        public static readonly RoutedEvent ExecuteClickedEvent = EventManager.RegisterRoutedEvent("ExecuteClickedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Header));
        public static readonly RoutedEvent OptionClickedEvent = EventManager.RegisterRoutedEvent("OptionClickedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Header));

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

        public event RoutedEventHandler ExecuteClicked
        {
            add { AddHandler(ExecuteClickedEvent, value); }
            remove { RemoveHandler(ExecuteClickedEvent, value); }
        }

        public event RoutedEventHandler OptionClicked
        {
            add { AddHandler(OptionClickedEvent, value); }
            remove { RemoveHandler(OptionClickedEvent, value); }
        }

        private void OnHomeClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Header.HomeClickedEvent));
        }

        private void OnCreateClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Header.CreateClickedEvent));
        }

        private void OnExecuteClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Header.ExecuteClickedEvent));
        }

        private void OnOptionClicked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Header.OptionClickedEvent));
        }

    }
}
