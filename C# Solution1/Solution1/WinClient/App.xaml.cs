using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WebApiClient;
using WinClient.Primes.Model;
using WinClient.Primes.View;
using WinClient.Primes.ViewModel;
using WinClient.Products2.View;
using WinClient.Products2.ViewModel;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    IServiceCollection serviceCollection = new ServiceCollection();
        //    ConfigureServices(serviceCollection);

        //    //retrieve ProductsView from the IServiceCollection, then call its Show method
        //    IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        //    ProductsView view = serviceCollection.BuildServiceProvider().GetService<ProductsView>();
        //    view.Show();
        //}

        //private void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddTransient<ProductsView>();
        //    services.AddTransient<ProductsViewModel>();
        //    services.AddTransient<IProductRepository, ProductRepository>(s => new ProductRepository("https://sdineen.uk/api/product/"));
        //    //Func<IServiceProvider,TService> is the factory that creates the service.
        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            //retrieve PrimesView from the IServiceCollection, then call its Show method
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            PrimesView view = serviceCollection.BuildServiceProvider().GetService<PrimesView>();
            view.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<PrimesView>();
            services.AddTransient<PrimesViewModel>();
            services.AddTransient<IPrimesModel, PrimesModel>();
        }
    }
}
