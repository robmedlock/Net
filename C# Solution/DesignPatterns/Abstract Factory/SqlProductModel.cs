using System;
using System.Collections.Generic;

namespace DesignPatterns.Abstract_Factory
{
    public class SqlProductModel : IProductModel
    {
        public ICollection<Product> Products
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Create(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Product SelectById(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> SelectByName(string partOfName)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}