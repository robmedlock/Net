using System;
using System.Linq;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://sdineen.uk/api/product";
            ProductRepository repository = new ProductRepository(url);
            repository.SelectAllAsync().Result.ToList().ForEach(p => Console.WriteLine(p.Name));
        }
    }
}
