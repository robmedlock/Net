﻿using ClassLibrary.Entity;
using System.IO;
using Xunit;

namespace ClassLibrary.JSON.Test
{
    public class JsonProductRepositoryIntegrationTest
    {
        [Fact]
        public void JsonSerializationTest()
        {
            //arrange
            string path = @"C:\Users\Owner\Documents\products.json";
            File.Delete(path); //If the file to be deleted does not exist, no exception is thrown.
            JsonProductRepository productRepository = new JsonProductRepository();
            Product product1 = new Product("p1", "Pedigree Chum", 0.70, 1.42);
            Product product2 = new Product("p2", "Fork", 0.60, 1.31);

            //serializes product collection
            bool created1 = productRepository.Create(product1);
            bool created2 = productRepository.Create(product2);
            //deserializes product collection
            productRepository = new JsonProductRepository();
            //assert
            Assert.True(productRepository.SelectAll().Contains(product1));
            Assert.Equal(2, productRepository.SelectAll().Count);
        }
    }
}
