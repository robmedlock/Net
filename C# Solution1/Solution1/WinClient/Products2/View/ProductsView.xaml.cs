using System.Windows;
using WinClient.Products2.ViewModel;

namespace WinClient.Products2.View
{
    public partial class ProductsView : Window
    {
        public ProductsView(ProductsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            SearchBox.Focus();
        }
    }
}
