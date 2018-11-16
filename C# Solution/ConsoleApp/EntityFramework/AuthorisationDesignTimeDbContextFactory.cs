using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using WebClient.Data;
using System.Reflection;

/*
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
    public class AuthorisationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {      
        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=authentication;User ID=sa;Password=carpond";

            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString, b => b.MigrationsAssembly(assemblyName)).Options;

            return new ApplicationDbContext(options);
        }
    }
}
*/

/*
Package manager console commands

Authentication tables
Add-Migration -Context ApplicationDbContext Initial
Update-Database -Context ApplicationDbContext -Verbose

CLI commands
1.	add the following to the ItemGroup in the csproj file
<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />
2.	In Solution Explorer, right-click the project and choose Open in File Explorer from the context menu.
3.	Enter  "cmd" in the address bar and press Enter.
> dotnet ef database drop
Authentication tables
> dotnet ef migrations add -c ApplicationDbContext Initial
> dotnet ef database update -c ApplicationDbContext

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
