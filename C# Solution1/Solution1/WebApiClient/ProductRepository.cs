using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Linq;

namespace WebApiClient
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double RetailPrice { get; set; }
        public byte[] RowVersion { get; set; }
    }

    public class ProductRepository 
    {
        private string uri;
        public ProductRepository (string uri) => this.uri = uri;

        public async Task<bool> CreateAsync(Product product)
        {
            using (HttpClient client = new HttpClient())
            {
                //Send the product, encoded as JSON, in a POST request to the specified Uri 
                HttpResponseMessage response = await client.PostAsJsonAsync(uri, product);
                return response.StatusCode == HttpStatusCode.Created;
            }
        }

        public async Task<ICollection<Product>> SelectAllAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                //string json = await response.Content.ReadAsStringAsync();
                //HttpStatusCode statusCode = response.StatusCode;
                IEnumerable<Product> products =
                    await response.Content.ReadAsAsync<IEnumerable<Product>>();
                return products.ToList();
            }
        }

        public async Task<Product> SelectByIdAsync(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri + id);
                return await response.Content.ReadAsAsync<Product>();
            }
        }

        public async Task<ICollection<Product>> SelectByNameAsync(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri + name);
                IEnumerable<Product> products =
                    await response.Content.ReadAsAsync<IEnumerable<Product>>();
                return products.ToList();
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using (HttpClient client = new HttpClient())
            {
                //Send the product, encoded as JSON, in a POST request to the specified Uri 
                HttpResponseMessage response = await client.PutAsJsonAsync(uri+product.Id, product);
                return response.StatusCode == HttpStatusCode.NoContent;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(uri + id);
                return response.StatusCode == HttpStatusCode.NoContent;
            }
        }
    }
}
