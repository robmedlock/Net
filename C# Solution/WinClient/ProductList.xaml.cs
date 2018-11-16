using ClassLibrary.Entity;
using ClassLibrary.RepositoryInterfaces;
using ClassLibrary.WebApiClient;
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
using System.Windows.Shapes;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        private IProductRepositoryAsync productRepository = new ProductRepository("http://sdineen.uk/api/productservice/");

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
