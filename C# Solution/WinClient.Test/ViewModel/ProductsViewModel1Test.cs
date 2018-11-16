using ClassLibrary.Entity;
using ClassLibrary.RepositoryInterfaces;
using Moq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WinClient.Products.ViewModel;
using Xunit;

namespace WinClient.Tests.ViewModel
{
    public class ProductsViewModel1Test
    {
        [Fact]
        public void ProductsProperty_ShouldRaisePropertyChangedEvent()
        {
            //arrange
            Mock<IProductRepositoryAsync> doc = new Mock<IProductRepositoryAsync>();
            ProductsViewModel sut = new ProductsViewModel(doc.Object);
            //add a delegate instance to the ViewModel's PropertyChanged event to enable tracking
            bool eventRaised = false;
            PropertyChangedEventArgs eventArgs = null;
            ((INotifyPropertyChanged)sut).PropertyChanged +=
                (object sender, PropertyChangedEventArgs e) => { eventRaised = true; eventArgs = e; };

            // Act
            sut.Products = null;

            // Assert
            Assert.True(eventRaised);
            Assert.Equal("Products", eventArgs.PropertyName);
        }

        [Fact]
        public void AddProduct_ShouldPassProductIntoCreateMethod()
        {
            // Arrange
            Mock<IProductRepositoryAsync> doc = new Mock<IProductRepositoryAsync>();
            ProductsViewModel1 viewModel = new ProductsViewModel1(doc.Object);
            viewModel.Id = "p1";
            viewModel.Name = "Dog's Dinner";
            viewModel.CostPrice = 1.50;

            // Act
            viewModel.AddProductCommand.Execute(null);

            // Assert
            doc.Verify(pm => pm.CreateAsync(It.Is<Product>(p => p.Id == "p1")));
        }

        [Fact]
        public void DeleteProduct_ShouldPassProductIdIntoDeleteMethod()
        {
            //arrange
            Mock<IProductRepositoryAsync> doc = new Mock<IProductRepositoryAsync>();
            ProductsViewModel1 viewModel = new ProductsViewModel1(doc.Object);
            viewModel.SelectedProduct = new Product { Id = "p1" };

            // Act
            viewModel.DeleteProductCommand.Execute(null);

            // Assert
            doc.Verify(repo => repo.DeleteAsync("p1"));
        }

        [Fact]
        public void LoadData_ShouldLoadProducts()
        {
            // Arrange
            ICollection<Product> products = new List<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31),
                new Product("p3", "Fork", 0.75, 1.57),
                new Product("p4", "Spaghetti", 0.90, 1.92),
                new Product("p5", "Cheddar Cheese", 0.65, 1.47),
                new Product("p6", "Bean bag", 15.20, 32.20),
                new Product("p7", "Bookcase", 22.30, 46.32),
                new Product("p8", "Table", 55.20, 134.80),
                new Product("p9", "Chair", 43.70, 110.20),
                new Product("p10", "Doormat", 3.20, 7.40)
            };
            Mock<IProductRepositoryAsync> doc = new Mock<IProductRepositoryAsync>();
            ProductsViewModel1 viewModel = new ProductsViewModel1(doc.Object);
            doc.Setup(m => m.SelectByNameAsync(It.IsAny<string>())).Returns(
                Task.FromResult<ICollection<Product>>(products));

            // Act
            viewModel.LoadData();

            // Assert
            Assert.Equal(10, viewModel.Products.Count);
            var product = viewModel.Products.SingleOrDefault(p => p.Id == "p1");
            Assert.Equal("Pedigree Chum", product.Name);
            product = viewModel.Products.SingleOrDefault(p => p.Id == "p2");
            Assert.Equal("Knife", product.Name);
        }
        [Fact]
        [Trait("WinClient", "Unit Test")]
        public void SearchPropertySetter_ShouldSetProductsProperty()
        {
            // Arrange
            ICollection<Product> products = new List<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31),
                new Product("p3", "Fork", 0.75, 1.57),
                new Product("p4", "Spaghetti", 0.90, 1.92),
                new Product("p5", "Cheddar Cheese", 0.65, 1.47),
                new Product("p6", "Bean bag", 15.20, 32.20),
                new Product("p7", "Bookcase", 22.30, 46.32),
                new Product("p8", "Table", 55.20, 134.80),
                new Product("p9", "Chair", 43.70, 110.20),
                new Product("p10", "Doormat", 3.20, 7.40)
            };
            Mock<IProductRepositoryAsync> doc = new Mock<IProductRepositoryAsync>();
            ProductsViewModel1 viewModel = new ProductsViewModel1(doc.Object);
            doc.Setup(m => m.SelectByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(products);

            // Act
            viewModel.Search = "something";

            // Assert
            Assert.Equal(10, viewModel.Products.Count);

            var product = viewModel.Products.SingleOrDefault(p => p.Id == "p1");
            Assert.Equal("Pedigree Chum", product.Name);

            product = viewModel.Products.SingleOrDefault(p => p.Id == "p2");
            Assert.Equal("Knife", product.Name);
        }

    }
}
