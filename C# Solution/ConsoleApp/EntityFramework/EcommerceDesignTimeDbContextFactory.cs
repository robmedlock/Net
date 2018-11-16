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
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";

            DbContextOptions<EcommerceContext> options = new DbContextOptionsBuilder<EcommerceContext>()
                .UseSqlServer(connectionString, b => b.MigrationsAssembly(assemblyName)).Options;

            EcommerceContext context = new EcommerceContext(options);
            return context;
        }
    }
}

/*
Package manager console commands

Add-Migration -Context EcommerceContext Initial
Update-Database -Context EcommerceContext -Verbose

CLI commands
1.	add the following to the ItemGroup in the csproj file
<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />
2.	In Solution Explorer, right-click the project and choose Open in File Explorer from the context menu.
3.	Enter  "cmd" in the address bar and press Enter.
> dotnet ef database drop
> dotnet ef migrations add -c EcommerceContext Initial
> dotnet ef database update -c EcommerceContext

*/


//appsettings.json
//{
//  "ConnectionStrings": {
//    "AuthenticationConnection": "Data Source=.\\sqlexpress;Initial Catalog=authentication;User ID=sa;Password=carpond",
//    "EcommerceConnection": "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond"
//  }
//}


//string outputDirectory = AppDomain.CurrentDomain.BaseDirectory;//JSON file, select CopyToOutputDirectory
//string projectRoot = Directory.GetCurrentDirectory();
//string connectionString = new ConfigurationBuilder()
//    .SetBasePath(projectRoot)
//    .AddJsonFile("appsettings.json")
//    .Build().GetConnectionString("AuthenticationConnection");