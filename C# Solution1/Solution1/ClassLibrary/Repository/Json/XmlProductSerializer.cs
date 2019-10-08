//Nuget System.Runtime.Serialization.Xml
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using ClassLibrary.Entity;


namespace ClassLibrary.Repository.JSON
{
    public class XmlProductSerializer : IProductSerializer
    {
        private string path = @"C:\Users\Public\Documents\products.xml";
        public void WriteProducts(HashSet<Product> products)
        {
            var serializer = new DataContractSerializer(typeof(HashSet<Product>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.WriteObject(fs, products);
            }

        }

        public HashSet<Product> ReadProducts()
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    var serializer = new DataContractSerializer(typeof(HashSet<Product>));
                    return serializer.ReadObject(fs) as HashSet<Product>;
                }
            }
            return new HashSet<Product>();
        }
    }
}
