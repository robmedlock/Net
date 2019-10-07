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
        public async void Test()
        {
            var productRepository = new ProductRepository(url);
            ICollection<Product> products = await productRepository.SelectAllAsync();
            Assert.Equal(9, products.Count);

            Product product = new Product { Id = "p10", Name = "Tomatoes", CostPrice = 0.5, RetailPrice = 1.2 };
            bool created = await productRepository.CreateAsync(product);
            Assert.True(created);

            product.RetailPrice = 1.5;
            bool updated = await productRepository.UpdateAsync(product);
            Assert.True(updated);

            bool deleted = await productRepository.DeleteAsync("p10");
            Assert.True(deleted);

        }
    }
}
