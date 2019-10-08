using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using ClassLibrary.Entity;

//Requires Newtonsoft.Json.dll from NuGet
namespace ClassLibrary.Repository.JSON
{
    public class JsonProductSerializer : IProductSerializer
    {
        private string path = @"C:\Users\Public\Documents\products.json";

        public void WriteProducts(HashSet<Product> products)
        {
            string output = JsonConvert.SerializeObject(products);
            File.WriteAllText(path, output);
        }

        public HashSet<Product> ReadProducts()
        {
            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<HashSet<Product>>(File.ReadAllText(path));
            }
            return new HashSet<Product>();
        }
    }
}
