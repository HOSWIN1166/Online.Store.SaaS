using Microsoft.EntityFrameworkCore;
using Online.Store.SaaS.Domain.Migrations;
using Online.Store.SaaS.Domain.Models.Contexts;
using Online.Store.SaaS.Domain.Models.Contracts;
using Online.Store.SaaS.Domain.Models.Domains;

namespace Online.Store.SaaS.Domain.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertAsync(Product product)
        {
            using (_dbContext)
            {
                try
                {
                    _dbContext.Product.Add(product);
                    await SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Product.Attach(product);
            _dbContext.Entry(product).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = _dbContext.Product.Find(id);
            _dbContext.Remove(entityToDelete);
            await SaveChanges();
        }

        public virtual async Task DeleteAsync(Product product)
        {
            if (_dbContext.Entry(product).State == EntityState.Detached)
            {
                _dbContext.Product.Attach(product);
            }
            _dbContext.Remove(product);
            await SaveChanges();
        }

        public async Task<List<Product>> Select()
        {
            var q = _dbContext.Product.ToListAsync();
            return await q;
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            var q = _dbContext.Product.FindAsync(id);
            return await q;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
