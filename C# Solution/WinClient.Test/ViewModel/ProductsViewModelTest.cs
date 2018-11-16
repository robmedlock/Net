using ClassLibrary.RepositoryInterfaces;
using Moq;
using System.ComponentModel;
using WinClient.Products.ViewModel;
using Xunit;

namespace WinClient.Tests.ViewModel
{
    public class ProductsViewModelTest
    {
        [Fact]
        public void SearchPropertySetter_ShouldCallSelectByNameAsync()
        {
            //arrange
            Mock<IProductRepositoryAsync> doc = new Mock<IProductRepositoryAsync>();
            ProductsViewModel sut = new ProductsViewModel(doc.Object);

            // Act
            sut.Search = "something";

            // Assert
            doc.Verify(model => model.SelectByNameAsync("something"));
         }

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

        //[Fact]
        //[Trait("WinClient", "Unit Test")]
        //public void AddProduct_ShouldPassProductIntoCreateMethod()
        //{
        //    // Arrange
        //    viewModel.Id = "p1";
        //    viewModel.Name = "Dog's Dinner";
        //    viewModel.CostPrice = 1.50;

        //    // Act
        //    viewModel.AddProductCommand.Execute(null);

        //    // Assert
        //    productServiceClientMock.Verify(pm => pm.CreateAsync(It.Is<Product>(p=>p.Id=="p1")));
        //}

        //[Fact]
        //[Trait("WinClient", "Unit Test")]
        //public void DeleteProduct_ShouldPassProductIdIntoDeleteMethod()
        //{
        //    // Arrange
        //    viewModel.SelectedProduct = new Product { Id = "p1" };

        //    // Act
        //    viewModel.DeleteProductCommand.Execute(null);

        //    // Assert
        //    productServiceClientMock.Verify(pm => pm.DeleteAsync("p1"));
        //}

        //[Fact]
        //[Trait("Category", "Unit Test")]
        //public void LoadData_ShouldLoadProducts()
        //{
        //    // Arrange
        //    productServiceClientMock.Setup(m => m.SelectByNameAsync(It.IsAny<string>())).Returns(products);

        //    // Act
        //    viewModel.LoadData();

        //    // Assert
        //    Assert.Equal(2, viewModel.Products.Count);
        //    var product = viewModel.Products.SingleOrDefault(p => p.Id == "p1");
        //    Assert.Equal("Dog's Dinner", product.Name);
        //    product = viewModel.Products.SingleOrDefault(p => p.Id == "p2");
        //    Assert.Equal("Knife", product.Name);  
        //}
        //    [Fact]
        //    [Trait("WinClient", "Unit Test")]
        //    public void SearchPropertySetter_ShouldCallSelectByNameAsync()
        //    {
        //        // Arrange
        //        productServiceClientMock.Setup(m => m.SelectByNameAsync(It.IsAny<string>()))
        //            .ReturnsAsync(products);

        //        // Act
        //        viewModel.Search = "something";

        //        // Assert
        //        Assert.Equal(2, viewModel.Products.Count);
        //        var product = viewModel.Products.SingleOrDefault(p => p.Id == "p1");
        //        Assert.Equal("Dog's Dinner", product.Name);
        //        product = viewModel.Products.SingleOrDefault(p => p.Id == "p2");
        //        Assert.Equal("Knife", product.Name);
        //    }

    }
}
