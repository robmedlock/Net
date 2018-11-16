using ClassLibrary.Entity;
using ClassLibrary.JSON;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ClassLibrary.JSON.Test
{
    public class JsonProductRepositoryInteractionsTest
    {
        [Fact]
        public void Create_CallsWriteProductMethodOfSerializer()
        {
            //arrange
            Mock<IProductSerializer> serializer = new Mock<IProductSerializer>();
            HashSet<Product> set = new HashSet<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31)
            };
            serializer.Setup(s => s.ReadProducts()).Returns(set);

            var productRepository = new JsonProductRepository(serializer.Object);
            Product product = new Product("p11", "Shark cage", 400);

            //act
            bool created = productRepository.Create(product);

            //assert
            serializer.Verify(s => s.WriteProducts(It.IsAny<ISet<Product>>()));
        }

        [Fact]
        public void SelectAll_ShouldReturnCollectionOfProducts()
        {
            //arrange
            Mock<IProductSerializer> serializer = new Mock<IProductSerializer>();
            HashSet<Product> set = new HashSet<Product> {
                new Product("p1", "Pedigree Chum", 0.70, 1.42),
                new Product("p2", "Knife", 0.60, 1.31)
            };
            serializer.Setup(s => s.ReadProducts()).Returns(set);
            var productRepository = new JsonProductRepository(serializer.Object);

            //act
            ICollection<Product> products = productRepository.SelectAll();

            //assert
            serializer.Verify(s => s.ReadProducts());
            Assert.Equal(set, products);
        }
    }
}
