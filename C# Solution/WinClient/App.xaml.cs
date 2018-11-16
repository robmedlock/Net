using ClassLibrary.RepositoryInterfaces;
using ClassLibrary.WebApiClient;
using System.Windows;
using Unity;
using Unity.Injection;
using WinClient.Primes.Model;
using WinClient.Primes.View;
using WinClient.Products.View;

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
            StartProductsApplication();
            //StartPrimesApplication();
        }

        private void StartPrimesApplication()
        {
            IUnityContainer container = new UnityContainer();
            //PrimesViewModel constructor takes interface argument
            //so need to register association between IPrimesModel
            //and implementing class.
            container.RegisterType<IPrimesModel, PrimesModel>();
            container.Resolve<PrimesView>().Show();
        }

        private static void StartProductsApplication()
        {
            string url = "http://sdineen.uk/api/productservice/";
            IUnityContainer container = new UnityContainer();
            //ProductsViewModel constructor takes interface argument
            //so need to register association between IProductRepositoryAsync
            //and implementing class.
            //ProductRepository constructor takes string argument, which
            //is passed in using InjectionConstructor
            container.RegisterType<IProductRepositoryAsync, ProductRepository>(
            new InjectionConstructor(url));
            //container.Resolve<ProductsView>().Show();
            ProductsView view = container.Resolve<ProductsView>();
            view.Show();
        }
    }
}
