using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WebApiClient.Test
{
    [Collection("Collection 1")]
    public class ProductRepositoryIntegrationTest
    {
        private string url = "http://sdineen.uk/api/product/";

        [Fact]
        public async void SelectAllAsync_Should_Return_All_Products()
        {
            var productRepository = new ProductRepository(url);
            ICollection<Product> products = await productRepository.SelectAllAsync();
            Assert.Equal(9, products.Count);
        }
    }
}
