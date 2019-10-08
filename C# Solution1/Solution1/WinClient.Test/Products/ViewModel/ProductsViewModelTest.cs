using Moq;
using System.ComponentModel;
using WebApiClient;
using WinClient.Products.ViewModel;
using Xunit;

namespace WinClient.Test.Products.ViewModel
{
    public class ProductsViewModelTest
    {
        [Fact]
        public void SearchPropertySetter_ShouldCallSelectByNameAsync()
        {
            //arrange
            Mock<IProductRepository> mockRepository = new Mock<IProductRepository>();
            ProductsViewModel viewModel = new ProductsViewModel(mockRepository.Object);

            // Act
            viewModel.Search = "something";

            // Assert
            mockRepository.Verify(model => model.SelectByNameAsync("something"));
        }

        [Fact]
        public void ProductsProperty_ShouldRaisePropertyChangedEvent()
        {
            //arrange
            Mock<IProductRepository> doc = new Mock<IProductRepository>();
            ProductsViewModel viewModel = new ProductsViewModel(doc.Object);

            //add a delegate instance to the ViewModel's PropertyChanged event to enable tracking
            bool eventRaised = false;
            PropertyChangedEventArgs eventArgs = null;
            ((INotifyPropertyChanged)viewModel).PropertyChanged +=
                (object sender, PropertyChangedEventArgs e) => { eventRaised = true; eventArgs = e; };

            // Act
            viewModel.Products = null; //sets Products property

            // Assert
            Assert.True(eventRaised);
            Assert.Equal("Products", eventArgs.PropertyName);
        }
    }
}

