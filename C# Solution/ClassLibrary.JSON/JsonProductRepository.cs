using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ClassLibrary.RepositoryInterfaces;
using ClassLibrary.Entity;

namespace ClassLibrary.JSON
{
    public class JsonProductRepository : IProductRepository
    {
        private IProductSerializer serializer;
        private ISet<Product> products = new HashSet<Product>();

        //called from state test
        public JsonProductRepository(ISet<Product> products)
        {
            this.products = products;
        }

        //called from interactions test
        public JsonProductRepository(IProductSerializer serializer)
        {
            this.serializer = serializer;
            this.products = serializer.ReadProducts();
        }

        public bool Create(Product product)
        {
            bool added = products.Add(product);
            serializer?.WriteProducts(products); //Null-conditional Operator
            return added;
        }

        public Task<bool> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            return (products as HashSet<Product>).RemoveWhere(p => p.Id == id) == 1;
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> SelectAll()
        {
            return products;
        }

        public Task<ICollection<Product>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }

        public Product SelectById(string id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public Task<Product> SelectByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> SelectByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            return products.Remove(product) ? products.Add(product) : false;
        }

        public Task<bool> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
