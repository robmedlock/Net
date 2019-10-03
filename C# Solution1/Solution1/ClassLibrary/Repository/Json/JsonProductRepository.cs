using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Entity;

namespace ClassLibrary.Repository.JSON
{
    public class JsonProductRepository : IProductRepository
    {
        private IProductSerializer serializer;
        private ISet<Product> products = new HashSet<Product>();

        //integration test
        public JsonProductRepository()
        {
            serializer = new JsonProductSerializer();
        }

        //interactions test
        public JsonProductRepository(IProductSerializer serializer)
        {
            this.serializer = serializer;
        }

        //state test
        public JsonProductRepository(ISet<Product> products)
        {
            this.products = products;
        }

        public bool Create(Product product)
        {
            bool added = products.Add(product);
            serializer?.WriteProducts(products); //Null-conditional Operator
            return added;
        }

        public bool Delete(string id)
        {
            return (products as HashSet<Product>).RemoveWhere(p => p.Id == id) == 1;
        }

        public ICollection<Product> SelectAll()
        {
            if(serializer != null)
            {
                products = serializer.ReadProducts();
            }
            return products;
        }

        public Product SelectById(string id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Product product)
        {
            return products.Remove(product) ? products.Add(product) : false;
        }
    }
}
