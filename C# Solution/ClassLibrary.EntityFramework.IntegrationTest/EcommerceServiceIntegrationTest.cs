using System.Collections.Generic;
using System.Linq;
using Xunit;
using System;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.ServiceInterfaces;
using ClassLibrary.Entity;
using Microsoft.Extensions.Configuration;
using ClassLibrary.EntityFramework.Test;

namespace ClassLibrary.EntityFramework.IntegrationTest
{
    [Collection("Collection 1")]
    public class EcommerceServiceIntegrationTest
    {
        private IEcommerceService service;
        private EcommerceContext context;
        public EcommerceServiceIntegrationTest()
        {
            context = ContextFactory.SqlServerEcommerceContext;

            service = new EcommerceService(new ProductRepository(context), 
                 new OrderRepository(context));
        }
        

        [Fact]
        public async void AddProductToOrderTest()
        {
            AddAccount(context);
            AddProducts(context);
            AddOrders(context);
            Order order = await service.AddProductToOrderAsync("p5", "acc1");
            Assert.True(order.LineItems.Any(li=>li.Product.Id=="p5"));
        }

        [Fact]
        public async void RemoveProductFromOrderTest()
        {
            AddAccount(context);
            AddProducts(context);
            AddOrders(context);
            await service.RemoveProductFromOrderAsync("p1", "acc1");
            Assert.Equal(1, context.Orders.First().LineItems.First(li=>li.Product.Id=="p1").Quantity);
        }

        [Fact]
        public async void SelectOrCreateProvisionalOrderByAccountIdAsyncTest_should_not_create_order()
        {
            AddAccount(context);
            AddProducts(context);
            AddOrders(context);
            Assert.Equal(2, context.Orders.Count());
            Order order = await service.CreateOrSelectProvisionalOrderForExistingAccountAsync("acc1");
            Assert.Equal(2, context.Orders.Count());
        }

        [Fact]
        public async void SelectOrCreateProvisionalOrderByAccountIdAsyncTest_should_create_order()
        {
            AddAccount(context);
            AddProducts(context);
            Assert.Equal(0, context.Orders.Count());
            Order order = await service.CreateOrSelectProvisionalOrderForExistingAccountAsync("acc1");
            Assert.Equal(1, context.Orders.Count());
        }

        [Fact]
        public async void ConfirmOrderAsyncTest_should_change_status_of_provisional_order_to_confirmed()
        {
            AddAccount(context);
            AddProducts(context);
            AddOrders(context);
            await service.ConfirmOrderAsync("acc1");
            Assert.False(context.Orders.Any(o => o.OrderStatus == OrderStatus.Provisional));
        }

        /*
        [Fact]
        public async void ConfirmOrderAsyncTest_should_throw_exception()
        {
            AddAccount(context);
            AddProducts(context);
            Order order2 = new Order
            {
                AccountId = "acc1",
                OrderStatus = OrderStatus.Confirmed,
                LineItems = new List<LineItem>{
                        new LineItem
                        {
                            //set foreign key property, not relation property
                            ProductId="p3",
                            Quantity = 1,
                            //Setting the Product property causes the following Exception
                            //The instance of entity type 'Product' cannot be tracked because 
                            //another instance with the same key value for {'Id'} is already being tracked. 
                            //Product = new Product("p1", "Pedigree Chum", 0.70, 1.42)
                        },
                        new LineItem
                        {
                            ProductId="p4",
                            Quantity = 1
                        }
                }
            };
            context.Add(order2);
            context.SaveChanges();

            await Assert.ThrowsAsync<InvalidOperationException>(
                                () => service.ConfirmOrderAsync("acc1"));
        }
        */

        /*
                 [Fact]
        public async void DeleteProductAsync_should_change_discontinued_property_to_true()
        {
            AddAccount(context);
            AddProducts(context);
            AddOrder(context);
            bool deleted = await service.DeleteProductAsync("p1");//p1 is in the Order
            Assert.False(deleted);
            Assert.True(context.Products.Find("p1").IsDiscontinued);
        }

        [Fact]
        public async void DeleteProductAsync_should_delete_product_not_in_order()
        {
            AddAccount(context);
            AddProducts(context);
            AddOrder(context);
            bool deleted = await service.DeleteProductAsync("p5");//p5 is not in the Order
            Assert.True(deleted);
            Assert.Null(context.Products.Find("p5"));
        }
        */



        private void AddAccount(EcommerceContext context)
        {
            //add a row to the Account table
            context.Accounts.Add(new Account { Id = "acc1", Name = "John Smith" });
            context.SaveChanges();
        }

        private void AddProducts(EcommerceContext context)
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
            context.Products.Add(new Product("p10", "Doormat", 3.20, 7.40, true));//discontinued
            context.SaveChanges();
        }

        private void AddOrders(EcommerceContext context)
        {
            Order order1 = new Order
            {
                AccountId = "acc1",
                OrderStatus = OrderStatus.Provisional,
                LineItems = new List<LineItem>{
                        new LineItem
                        {
                            //set foreign key property, not relation property
                            ProductId="p1",
                            Quantity = 2,
                            //Setting the Product property causes the following Exception
                            //The instance of entity type 'Product' cannot be tracked because 
                            //another instance with the same key value for {'Id'} is already being tracked. 
                            //Product = new Product("p1", "Pedigree Chum", 0.70, 1.42)
                        },
                        new LineItem
                        {
                            ProductId="p2",
                            Quantity = 1
                        }
                }
            };
            context.Add(order1);

            Order order2 = new Order
            {
                AccountId = "acc1",
                OrderStatus = OrderStatus.Confirmed,
                LineItems = new List<LineItem>{
                        new LineItem
                        {
                            //set foreign key property, not relation property
                            ProductId="p3",
                            Quantity = 1,
                            //Setting the Product property causes the following Exception
                            //The instance of entity type 'Product' cannot be tracked because 
                            //another instance with the same key value for {'Id'} is already being tracked. 
                            //Product = new Product("p1", "Pedigree Chum", 0.70, 1.42)
                        },
                        new LineItem
                        {
                            ProductId="p4",
                            Quantity = 1
                        }
                }
            };
            context.Add(order2);
            context.SaveChanges();

        }

        /*
        [Fact]
        public async void SelectProductsAsync_should_exclude_discontinued_products()
        {
            AddProducts(context);
            ICollection<Product> products = await service.SelectProductsAsync();
            Assert.Equal(9, products.Count);
        }
        */

    }
}
