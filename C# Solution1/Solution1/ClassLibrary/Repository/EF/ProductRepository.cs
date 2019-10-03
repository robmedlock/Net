using Microsoft.EntityFrameworkCore;
using ClassLibrary.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary.Repository.EF
{
    public class ProductRepository : IProductRepository, IProductRepositoryAsync
    {
        private EcommerceContext context;

        public ProductRepository(EcommerceContext context)
        {
            this.context = context;
        }

        public bool Create(Product product)
        {
            context.Products.Add(product);
            try
            {
                return context.SaveChanges() == 1;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> CreateAsync(Product product)
        {
            context.Products.Add(product);
            try
            {
                return await context.SaveChangesAsync() == 1;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return false;
            }
            context.Remove(product);
            return context.SaveChanges() == 1;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            Product product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            context.Remove(product);
            return await context.SaveChangesAsync() == 1;
        }

        public ICollection<Product> SelectAll()
        {
            return context.Products.ToList();
        }

        public async Task<ICollection<Product>> SelectAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public Product SelectById(string id)
        {
            return context.Products.Find(id);
        }

        public async Task<Product> SelectByIdAsync(string id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<ICollection<Product>> SelectByNameAsync(string name)
        {
            return await context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public bool Update(Product modifiedProduct)
        {
            Product product = context.Products.Find(modifiedProduct.Id);
            if (product == null)
            {
                return false;
            }
            product.CostPrice = modifiedProduct.CostPrice;
            product.RetailPrice = modifiedProduct.RetailPrice;
            return context.SaveChanges() == 1;
        }

        public async Task<bool> UpdateAsync(Product modifiedProduct)
        {
            Product product = context.Products.Find(modifiedProduct.Id);
            if (product == null) {
                return false;
            }
            product.CostPrice = modifiedProduct.CostPrice;
            product.RetailPrice = modifiedProduct.RetailPrice;
            return await context.SaveChangesAsync() == 1;
        }
    }
}
