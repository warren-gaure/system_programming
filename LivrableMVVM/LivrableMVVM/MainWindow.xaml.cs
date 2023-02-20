﻿using System;
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

namespace LivrableMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnHomeClicked(object sender, RoutedEventArgs e)
        {
            this.Home.Visibility = Visibility.Visible;
            this.Create.Visibility = Visibility.Hidden;
            this.Execute.Visibility = Visibility.Hidden;
            this.Option.Visibility = Visibility.Hidden;
        }

        private void OnCreateClicked(object sender, RoutedEventArgs e)
        {
            this.Home.Visibility = Visibility.Hidden;
            this.Create.Visibility = Visibility.Visible;
            this.Execute.Visibility = Visibility.Hidden;
            this.Option.Visibility = Visibility.Hidden;
        }

        private void OnExecuteClicked(object sender, RoutedEventArgs e)
        {
            this.Home.Visibility = Visibility.Hidden;
            this.Create.Visibility = Visibility.Hidden;
            this.Execute.Visibility = Visibility.Visible;
            this.Option.Visibility = Visibility.Hidden;
        }

        private void OnOptionClicked(object sender, RoutedEventArgs e)
        {
            this.Home.Visibility = Visibility.Hidden;
            this.Create.Visibility = Visibility.Hidden;
            this.Execute.Visibility = Visibility.Hidden;
            this.Option.Visibility = Visibility.Visible;
        }
    }
}
