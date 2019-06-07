using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private List<Product> products = new List<Product>
        {
            new Product("p1", "Baked Beans", 0.2, 0.5),
            new Product("p2", "Bucket", 0.9, 1.8)
        };

        public bool Create(Product product)
        {
            products.Add(product);
            return true;
        }
        public bool Delete(string id)
        {
            return products.RemoveAll(p => p.Id == id) == 1;
        }

        public List<Product> SelectAll()
        {
            List<Product> products = new List<Product>
            {
                new Product("p1", "Baked Beans", 0.2, 0.5),
                new Product("p2", "Bucket", 0.9, 1.8)
            };
            return products;
        }

        public Product SelectById(string id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Product product)
        {
            int index = products.FindIndex(p => p.Equals(product));
            if (index == -1)
                return false;
            products[index] = product;
            return true;
        }
    }
}
