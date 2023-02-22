﻿using Livrable3.Model;
using Livrable3.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Livrable3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };

            MainWindow.Show();
            base.OnStartup(e);
            Thread thread = new Thread(new ThreadStart(() => Communication.Start()));
            thread.Start();
        }
    }
}
