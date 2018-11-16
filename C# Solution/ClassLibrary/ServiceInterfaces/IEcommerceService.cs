using ClassLibrary.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.ServiceInterfaces
{
    public interface IEcommerceService
    {
        /// <summary>
        /// returns all products if no argument
        /// </summary>
        /// <param name="partOfName">part of a product's name</param>
        /// <returns>Products with Discontinued property = false</returns>
        Task<ICollection<Product>> SelectProductsAsync(string partOfName = null);

        /// <summary>
        /// Called from Register method of AccountController
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<int> CreateOrderAsync(Order order);

        /// <summary>
        /// add the product to the provisional order with the specified accountId
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<Order> AddProductToOrderAsync(string productId, string accountId);

        /// <summary>
        /// Creates a new Order with the specified AccountId and with OrderStatus = Provisional
        /// or returns an existing Provisional Order for the AccountId
        /// Called from Login method of AccountController
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<Order> CreateOrSelectProvisionalOrderForExistingAccountAsync(string accountId);

        /// <summary>
        /// change the status of the provisional order with the specified 
        /// accountId to confirmed
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task ConfirmOrderAsync(string accountId);

        /// <summary>
        /// remove the product from the provisional order with the specified 
        /// accountId
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task RemoveProductFromOrderAsync(string productId, string accountId);

        /// <summary>
        /// Called from Create method of ProductController 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<bool> CreateProductAsync(Product product);


        /*
         * additional methods
         */ 

        /// <summary>
        /// Called from Index method of OrderController
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>        
        Task<ICollection<Order>> SelectOrdersByAccountIdAsync(string accountId);

        /// <summary>
        /// Called from Details method of OrderController
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> SelectOrderAsync(int orderId);

        /// <summary>
        /// Called from Delete method of ProductController
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> SelectProductByIdAsync(string id);

        /// <summary>
        /// Delete product if it's in an order
        /// otherwise set discontinued property to true
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>true if deleted, false if discontinued</returns>
        Task<bool> DeleteProductAsync(string id);
    }
}