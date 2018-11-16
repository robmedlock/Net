using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ClassLibrary.EntityFramework.Test
{
    public class ContextFactory
    {
        public static EcommerceContext InMemoryEcommerceContext
        {
            get
            {
                string dbname = Guid.NewGuid().ToString();
                var options = new DbContextOptionsBuilder<EcommerceContext>()
                                  .UseInMemoryDatabase(dbname)
                                  .Options;
                return new EcommerceContext(options);
            }
        }

        public static EcommerceContext SqlServerEcommerceContext
        {
            get
            {
                string outputDirectory = AppDomain.CurrentDomain.BaseDirectory;//JSON file, select CopyToOutputDirectory
                string connectionString = new ConfigurationBuilder()
                    .SetBasePath(outputDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build().GetConnectionString("EcommerceConnection");

                var options = new DbContextOptionsBuilder<EcommerceContext>()
                    .UseSqlServer(connectionString).Options;

                EcommerceContext context = new EcommerceContext(options);
                TruncateTables(context);
                return context;
            }
        }

        private static void TruncateTables(EcommerceContext context)
        {
            int rows = context.Database.ExecuteSqlCommand("delete from LineItems");
            rows = context.Database.ExecuteSqlCommand("delete from Orders");
            rows = context.Database.ExecuteSqlCommand("delete from Products");
            rows = context.Database.ExecuteSqlCommand("delete from Accounts");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Orders', RESEED, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('LineItems', RESEED, 0)");
        }
    }
}

//appsettings.json
//select CopyToOutputDirectory
//
//{
//  "ConnectionStrings": {
//    "AuthenticationConnection": "Data Source=.\\sqlexpress;Initial Catalog=authentication;User ID=sa;Password=carpond",
//    "EcommerceConnection": "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond"
//  }
//}
