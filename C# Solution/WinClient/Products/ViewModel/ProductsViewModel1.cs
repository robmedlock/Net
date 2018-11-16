using ClassLibrary.Entity;
using ClassLibrary.RepositoryInterfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WinClient.Utility;

namespace WinClient.Products.ViewModel
{
    public class ProductsViewModel1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IProductRepositoryAsync productRepository;

        public ProductsViewModel1(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;
            LoadData();
            LoadCommands();
        }

        public async void LoadData()
        {
            ICollection<Product> productsCollection = await productRepository.SelectByNameAsync(Search);
            if (productsCollection != null)
            {
                Products = new ObservableCollection<Product>(productsCollection);
            }
        }

        /*         Bound Properties         */

        private string search;
        private ObservableCollection<Product> products;
        private string id;
        private string name;
        private double costPrice;
        private double retailPrice;
        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; }
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

        public ObservableCollection<Product> Products  //Bound to DataGrid ItemsSource
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

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

         public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double CostPrice
        {
            get { return costPrice; }
            set { costPrice = value; }
        }

        public double RetailPrice
        {
            get { return retailPrice; }
            set { retailPrice = value; }
        }











        /*         Operations         */

        private void LoadCommands()
        {
            AddProductCommand = new CustomCommand(AddProduct, CanAddProduct);
            DeleteProductCommand = new CustomCommand(DeleteProduct, CanDeleteProduct);
            UpdateProductCommand = new CustomCommand(UpdateProduct, CanUpdateProduct);
        }

        //AddProduct
        public CustomCommand AddProductCommand { get; private set; }
        private async void AddProduct(object obj)
        {
            Product product = new Product(Id,Name,CostPrice,RetailPrice);
            bool created = await productRepository.CreateAsync(product);

            //update the DataGrid
            if (created)
            {
                Products.Add(product);
            }
        }
        private bool CanAddProduct(object obj)
        {
            return true; //false to disable button
        }

        //DeleteProduct
        public CustomCommand DeleteProductCommand { get; private set; }
        private async void DeleteProduct(object obj)
        {
            bool deleted = await productRepository.DeleteAsync(SelectedProduct.Id);

            //update the DataGrid
            if (deleted)
            {
                Products.Remove(SelectedProduct);
            }
        }
        private bool CanDeleteProduct(object obj)
        {
            return true; //false to disable button
        }

        //UpdateProduct
        public CustomCommand UpdateProductCommand { get; private set; }
        private async void UpdateProduct(object obj)
        {
            bool updated = await productRepository.UpdateAsync(SelectedProduct);
        }
        private bool CanUpdateProduct(object obj)
        {
            return true; //false to disable button
        }
    }
}

