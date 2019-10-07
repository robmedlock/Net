using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WebApiClient;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        private ProductRepository productRepository = new ProductRepository("https://sdineen.uk/api/product/");

        public ProductList()
        {
            InitializeComponent();
            SearchBox.Focus();
            SearchBox_TextChanged(null, null);
        }


        private async void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollection<Product> products = await productRepository.SelectByNameAsync(SearchBox.Text);
            DataContext = products;
        }
    }
}
