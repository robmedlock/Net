using ClassLibrary.EntityFramework;
using ClassLibrary.RepositoryInterfaces;
using ConsoleApp.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Examples
{
   public  class EfConnectToDatabase
    {
        public static void Main()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";
            var options = new DbContextOptionsBuilder<EcommerceContext>()
                .UseSqlServer(connectionString).Options;

            EcommerceContext context = new EcommerceContext(options);
            //DbInitializer.Initialize(context);

            IProductRepositoryAsync productRepository = new ProductRepository(context);
            var products = productRepository.SelectAllAsync().Result;
            foreach (var item in products)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }
}

//string outputDirectory = AppDomain.CurrentDomain.BaseDirectory;//JSON file, select CopyToOutputDirectory
//string connectionString = new ConfigurationBuilder()
//    .SetBasePath(outputDirectory)
//    .AddJsonFile("appsettings.json")
//    .Build().GetConnectionString("EcommerceConnection");
