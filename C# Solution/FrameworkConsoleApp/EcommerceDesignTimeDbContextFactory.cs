using ClassLibrary.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace ConsoleApp.EntityFramework
{
    /// <summary>
    /// Requires Microsoft.EntityFrameworkCore.Design
    /// 
    /// A factory for creating derived DbContext instances. Implement this interface to enable design-time services 
    /// for context types that do not have a public default constructor. At design-time, derived DbContext 
    /// instances can be created in order to enable Migrations. 
    /// Design-time services will automatically discover implementations of this interface that are in the 
    /// startup assembly
    /// </summary>
    public class EcommerceDesignTimeDbContextFactory : IDesignTimeDbContextFactory<EcommerceContext>
    {      
        public EcommerceContext CreateDbContext(string[] args)
        {
            string outputDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetCurrentDirectory();
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            string connectionString = new ConfigurationBuilder()
                .SetBasePath(projectRoot)
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("EcommerceConnection");

            var options = new DbContextOptionsBuilder<EcommerceContext>()
                .UseSqlServer(connectionString, b => b.MigrationsAssembly(assemblyName)).Options;

            EcommerceContext context = new EcommerceContext(options);
            return context;
        }
    }
}


//appsettings.json
//{
//  "ConnectionStrings": {
//    "AuthenticationConnection": "Data Source=.\\sqlexpress;Initial Catalog=authentication;User ID=sa;Password=carpond",
//    "EcommerceConnection": "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond"
//  }
//}
