using ClassLibrary.Entity;
using System.Collections.Generic;

namespace ClassLibrary.Repository.JSON
{
    public interface IProductSerializer
    {
        ISet<Product> ReadProducts();
        void WriteProducts(ISet<Product> products);
    }
}