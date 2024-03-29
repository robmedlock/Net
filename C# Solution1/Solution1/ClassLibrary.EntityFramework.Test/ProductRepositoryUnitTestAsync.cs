﻿using ClassLibrary.Entity;
using ClassLibrary.Repository.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ClassLibrary.EntityFramework.Test
{
    public class ProductRepositoryUnitTestAsync
    {
        protected EcommerceContext context;
        public ProductRepositoryUnitTestAsync()
        {
            string dbname = Guid.NewGuid().ToString();
            context = new EcommerceContext(new DbContextOptionsBuilder<EcommerceContext>()
                              .UseInMemoryDatabase(dbname)
                              .Options);
        }

        ~ProductRepositoryUnitTestAsync() => context.Dispose();

        [Fact]
        public async void CreateAsync_Should_Add_Product()
        {
            //arrange
            Product product = new Product("p11", "Fridge", 100, 220);
            var productRepository = new ProductRepository(context);
            //act
            bool created = await productRepository.CreateAsync(product);
            //assert
            Assert.Single(context.Products);
        }

        [Fact]
        public virtual async void SelectAllAsync_Should_Return_All_Products()
        {
            //arrange
            SeedDatabase(context);
            var productRepository = new ProductRepository(context);
            //act
            ICollection<Product> products = await productRepository.SelectAllAsync();
            //assert
            Assert.Equal(10, products.Count);
        }

        [Fact]
        public async void SelectByIdAsync_Should_Return_Correct_Product()
        {
            //arrange
            SeedDatabase(context);
            var productRepository = new ProductRepository(context);
            //act
            Product product = await productRepository.SelectByIdAsync("p4");
            //assert
            Assert.Equal("Spaghetti", product.Name);
        }

        [Fact]
        public async void UpdateAsync_Should_Update_Product()
        {
            //arrange
            SeedDatabase(context);
            Product product = new Product("p1", "Pedigree Chum", 0.70, 1.50);
            var productRepository = new ProductRepository(context);
            //act
            await productRepository.UpdateAsync(product);
            //assert
            Assert.Equal(1.50, context.Products.Find("p1").RetailPrice);
        }

        [Fact]
        public async void Update_ContrivedOptimisticConcurrencyConflict()
        {
            //arrange
            SeedDatabase(context);
            var productRepository = new ProductRepository(context);
            Product product1 = context.Products.Find("p1");
            Product product2 = context.Products.Find("p1");
            product1.RetailPrice = 1.50;
            product2.RetailPrice = 1.55;

            //act

            //modifying a row will update the RowVersion column value
            bool updatedProduct1 = await productRepository.UpdateAsync(product1);

            //product1 RowVersion property and database RowVersion  
            //column values are now unequal, so the update will fail
            bool updatedProduct2 = await productRepository.UpdateAsync(product2);

            //assert
            Assert.True(updatedProduct1);
            Assert.False(updatedProduct2);
        }

        [Fact]
        public async void DeleteAsync_Should_Remove_Product()
        {
            //arrange
            SeedDatabase(context);
            var productRepository = new ProductRepository(context);
            //act
            await productRepository.DeleteAsync("p1");
            //assert
            Assert.Equal(9, context.Products.Count());
        }

        private void SeedDatabase(EcommerceContext context)
        {
            context.Products.Add(new Product("p1", "Pedigree Chum", 0.70, 1.42));
            context.Products.Add(new Product("p2", "Knife", 0.60, 1.31));
            context.Products.Add(new Product("p3", "Fork", 0.75, 1.57));
            context.Products.Add(new Product("p4", "Spaghetti", 0.90, 1.92));
            context.Products.Add(new Product("p5", "Cheddar Cheese", 0.65, 1.47));
            context.Products.Add(new Product("p6", "Bean bag", 15.20, 32.20));
            context.Products.Add(new Product("p7", "Bookcase", 22.30, 46.32));
            context.Products.Add(new Product("p8", "Table", 55.20, 134.80));
            context.Products.Add(new Product("p9", "Chair", 43.70, 110.20));
            context.Products.Add(new Product("p10", "Doormat", 3.20, 7.40));
            context.SaveChanges();
        }
    }
}
