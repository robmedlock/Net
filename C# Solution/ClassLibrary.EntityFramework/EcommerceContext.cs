using Microsoft.EntityFrameworkCore;
using ClassLibrary.Entity;
using System.IO;

namespace ClassLibrary.EntityFramework 
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext>options) 
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
    }
}
