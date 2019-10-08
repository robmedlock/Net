using ClassLibrary.Entity;
using ClassLibrary.Repository.JSON;
using System.IO;
using Xunit;

namespace ClassLibrary.Xml.Test
{
    public class XmlProductRepositoryIntegrationTest
    {
        [Fact]
        public void XmlSerializationTest()
        {
            //arrange
            string path = @"C:\Users\Owner\Documents\products.xml";
            File.Delete(path); //If the file to be deleted does not exist, no exception is thrown.

            IProductSerializer productSerializer = new XmlProductSerializer();
            ProductRepository productRepository = new ProductRepository(productSerializer);
            Product product1 = new Product("p1", "Pedigree Chum", 0.70, 1.42);
            Product product2 = new Product("p2", "Fork", 0.60, 1.31);

            //serializes product collection
            bool created1 = productRepository.Create(product1);
            bool created2 = productRepository.Create(product2);
            //deserializes product collection
            productRepository = new ProductRepository(productSerializer);
            //assert
            Assert.True(productRepository.SelectAll().Contains(product1));
            Assert.Equal(2, productRepository.SelectAll().Count);
        }
    }
}
