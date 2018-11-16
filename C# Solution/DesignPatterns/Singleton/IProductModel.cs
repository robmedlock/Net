
using System.Collections.Generic;

namespace DesignPatterns.Singleton
{
    public interface IProductModel
    {
        bool Create(Product product);
        Product SelectById(string id);
        ICollection<Product> Products { get; }
        ICollection<Product> SelectByName(string partOfName);
        bool Update(Product product);
        bool Delete(string id);
    }
}
