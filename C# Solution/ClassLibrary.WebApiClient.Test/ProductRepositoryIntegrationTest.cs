using ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using Xunit;

namespace ClassLibrary.WebApiClient.Test
{
    [Collection("Collection 1")]
    public class ProductRepositoryIntegrationTest
    {
        private string url = "http://sdineen.uk/api/productservice/";

        [Fact]
        public async void SelectAllAsync_Should_Return_All_Products()
        {
            var productRepository = new ProductRepository(url);
            ICollection<Product> products = await productRepository.SelectAllAsync();
            Assert.Equal(10, products.Count);
        }
    }
}
