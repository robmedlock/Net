using System.Collections.Generic;
using System.ComponentModel;
using WebApiClient;

namespace WinClient.Products.ViewModel
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IProductRepository productRepository;

        private string search;
        private ICollection<Product> products;
        public ProductsViewModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            LoadData();
        }

        private async void LoadData()
        {
            Products = await productRepository.SelectByNameAsync(Search);
        }

        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                LoadData();
            }
        }

        public ICollection<Product> Products  //Bound to DataGrid ItemsSource
        {
            get { return products; }
            set
            {
                products = value;
                //PropertyChanged null if there are no subscribers to the event, 
                //due to DataContext not being set
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Products"));
            }
        }
    }
}

