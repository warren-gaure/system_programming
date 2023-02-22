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
        private static string appID = "eb3bc824-ef72-482d-bc27-0580d5825c23";
        Mutex mutex = new Mutex(false, appID);
        protected override void OnStartup(StartupEventArgs e)
        {
            if (!mutex.WaitOne(0, false))
            {
                MessageBox.Show("An instance is already running.");
                return;
            }

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };

            GC.Collect();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
