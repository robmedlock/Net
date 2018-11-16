using ClassLibrary.Entity;
using System;

namespace Examples
{
    public class Polymorphism
    {
        public static void Main()
        {
            Product product1 = new NormalGood
            {
                Id = "p1",
                Name = "Dog Dinner",
                CostPrice = 0.4
            };
            Product product2 = new NormalGood
            {
                Id = "p2",
                Name = "Fork",
                CostPrice = 0.4
            };
            Product product3 = new VeblenGood
            {
                Id = "p3",
                Name = "Krug Champagne",
                CostPrice = 25
            };
            Product product4 = new VeblenGood
            {
                Id = "p4",
                Name = "Rolex watch",
                CostPrice = 700
            };

            Product[] products = new Product[4];
            products[0] = product1;
            products[1] = product2;
            products[2] = product3;
            products[3] = product4;

            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Name} Cost Price {product.CostPrice} Retail Price {product.RetailPrice}");
            }

            Console.ReadKey();
        }
    }
}
