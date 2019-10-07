using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Microsoft.Extensions.DependencyInjection
            //ServiceCollection services = new ServiceCollection();
            //services.AddScoped<IInfo, Info>();
            //// add the MainWindow itself into the IoC chain
            //services.AddScoped<MainWindow>();

            //IServiceProvider serviceProvider = services.BuildServiceProvider();
            //MainWindow mainWindow = serviceProvider.GetService<MainWindow>();
            //MainWindow.Show();
        }


    }
}
