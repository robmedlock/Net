using ClassLibrary.Entity;
using ClassLibrary.Repository.JSON;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ClassLibrary.Test.Repository.Json
{
    public class ProductRepositoryUnitTest
    {
        private HashSet<Product> set = new HashSet<Product>();

        public ProductRepositoryUnitTest()
        {
            set = new HashSet<Product> {
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
        }

        [Fact]
        public void Create_Product_AddsProductToCollection()
        {
            //arrange
            var productRepository = new ProductRepository(set);
            Product product = new Product("p11", "Sofa", 120);
            //act
            bool added = productRepository.Create(product);
            //assert
            Assert.Equal(11, set.Count);
        }

        [Fact]
        public void SelectAll_Should_Return_All_Products()
        {
            var productRepository = new ProductRepository(set);
            ICollection<Product> products = productRepository.SelectAll();
            Assert.Equal(10, products.Count);
        }

        [Fact]
        public void SelectById_ProductId_ReturnsProduct()
        {
            //arrange
            var productRepository = new ProductRepository(set);
            Product product = new Product("p1", "Pedigree Chum", 0.70, 1.42);

            //act
            Product retrievedProduct = productRepository.SelectById("p1");
            //assert
            Assert.NotNull(retrievedProduct);
            Assert.Equal(product, retrievedProduct);
        }

        [Fact]
        public void Update_Product_ModifiesProductInCollection()
        {
            //arrange
            var productRepository = new ProductRepository(set);
            Product updatedProduct = new Product("p1", "Pedigree Chum", 0.75, 1.50);
            //act
            bool updated = productRepository.Update(updatedProduct);
            //assert
            Assert.True(updated);
            Assert.Equal(1.50, set.First(p=>p.Id=="p1").RetailPrice);
        }

        [Fact]
        public void Delete_IdOfProduct_RemovesProductFromCollection()
        {
            //arrange
            var productRepository = new ProductRepository(set);
            //act
            bool deleted = productRepository.Delete("p1");
            //assert
            Assert.True(deleted);
            Assert.Equal(9, set.Count);
        }
    }
}
