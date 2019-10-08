using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Entity;

namespace ClassLibrary.Repository.JSON
{
    public class ProductRepository : IProductRepository
    {
        private IProductSerializer serializer;
        private HashSet<Product> products = new HashSet<Product>();

        //interactions test
        public ProductRepository(IProductSerializer serializer)
        {
            this.serializer = serializer;
        }

        //state test
        public ProductRepository(HashSet<Product> products)
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
            return products.RemoveWhere(p => p.Id == id) == 1;
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
