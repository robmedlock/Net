using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using ClassLibrary.Entity;

//Requires Newtonsoft.Json.dll from NuGet
namespace ClassLibrary.JSON
{
    public class JsonProductSerializer : IProductSerializer
    {
        private string path = @"C:\Users\Owner\Documents\products.json";

        public void WriteProducts(ISet<Product> products)
        {
            string output = JsonConvert.SerializeObject(products);
            File.WriteAllText(path, output);
        }

        public ISet<Product> ReadProducts()
        {
            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<ISet<Product>>(File.ReadAllText(path));
            }
            return new HashSet<Product>();
        }
    }
}
