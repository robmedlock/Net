using ClassLibrary.Entity;
using ClassLibrary.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Repository.EF
{
    public class EcommerceService : IEcommerceService
    {
        private IProductRepositoryAsync productRepository;
        private IOrderRepositoryAsync orderRepository;

        public EcommerceService(IProductRepositoryAsync productRepository, IOrderRepositoryAsync orderRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        public async Task<ICollection<Product>> SelectProductsAsync(string partOfName = null)
        {
            ICollection<Product> products = partOfName == null ?
                await productRepository.SelectAllAsync() :
                await productRepository.SelectByNameAsync(partOfName);

            return products;
            //return products.Where(p => p.IsDiscontinued == false).ToList();
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            return await orderRepository.CreateAsync(order);
        }

        public async Task<Order> AddProductToOrderAsync(string productId, string accountId)
        {
            Product product = await productRepository.SelectByIdAsync(productId);
            Order order = await orderRepository.SelectProvisionalOrderByAccountIdAsync(accountId);

            order.AddProduct(product, 1);
            await orderRepository.UpdateAsync(order);
            return order;
        }

        public async Task<Order> CreateOrSelectProvisionalOrderForExistingAccountAsync(string accountId)
        {
            Order order = await orderRepository.SelectProvisionalOrderByAccountIdAsync(accountId);

            if (order == null)
            {
                order = new Order();
                //setting AccountId foreign key property instead of Account navigation 
                //property prevents cascade insert
                order.AccountId = accountId;
                int orderId = await orderRepository.CreateAsync(order);
            }
            return order;
        }

        public async Task ConfirmOrderAsync(string accountId)
        {
            Order order = await orderRepository.SelectProvisionalOrderByAccountIdAsync(accountId);
            if (order == null)
            {
                throw new InvalidOperationException($"Provisional order for account {accountId} not found");
            }
            order.OrderStatus = OrderStatus.Confirmed;
            await orderRepository.UpdateAsync(order);
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            return await productRepository.CreateAsync(product);
        }

        public async Task<Product> SelectProductByIdAsync(string id)
        {
            return await productRepository.SelectByIdAsync(id);
        }

        public async Task<bool> DeleteProductAsync(string productId)
        {
            await productRepository.DeleteAsync(productId);
            return true;
            /*
            bool isProductInAnyOrder =
                orderRepository.SelectAll().Any(o => o.LineItems.Any(li => li.Product.Id == productId));
            if (isProductInAnyOrder)
            {
                //product is in an order: set its discontinued property
                Product product = await productRepository.SelectByIdAsync(productId);
                product.IsDiscontinued = true;
                await productRepository.UpdateAsync(product);
                return false;
            }
            else
            {
                //product is not in an order: delete it
                await productRepository.DeleteAsync(productId);
                return true;
            }
            */
        }

        public async Task RemoveProductFromOrderAsync(string productId, string accountId)
        {
            Product product = await productRepository.SelectByIdAsync(productId);
            Order order = await orderRepository.SelectProvisionalOrderByAccountIdAsync(accountId);
            order.RemoveProduct(product, 1);
            await orderRepository.UpdateAsync(order);
        }

        public async Task<ICollection<Order>> SelectOrdersByAccountIdAsync(string accountId)
        {
            return await orderRepository.SelectOrdersByAccountIdAsync(accountId);
        }

        public async Task<Order> SelectOrderAsync(int orderId)
        {
            return await orderRepository.SelectByOrderIdAsync(orderId);
        }

    }

}
