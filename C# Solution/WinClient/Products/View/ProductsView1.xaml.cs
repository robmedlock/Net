using System.Windows;
using WinClient.Products.ViewModel;

namespace WinClient.Products.View
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView1 : Window
    {
        public ProductsView1(ProductsViewModel1 viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            SearchBox.Focus();
        }
    }
}