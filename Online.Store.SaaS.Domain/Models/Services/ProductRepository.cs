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
                finally
                {
                    _dbContext?.Dispose();
                }

            }
        }
        public async Task UpdateAsync(Product product)
        {
            using (_dbContext)
            {
                try
                {
                    _dbContext.Product.Attach(product);
                    _dbContext.Entry(product).State = EntityState.Modified;
                    await SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _dbContext?.Dispose();
                }

            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entityToDelete = _dbContext.Product.Find(id);
                _dbContext.Remove(entityToDelete);
                await SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _dbContext?.Dispose();
            }

        }

        public virtual async Task DeleteAsync(Product product)
        {
            try
            {
                if (_dbContext.Entry(product).State == EntityState.Detached)
                {
                    _dbContext.Product.Attach(product);
                }
                _dbContext.Remove(product);
                await SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _dbContext?.Dispose();
            }

        }

        public async Task<List<Product>> Select()
        {
            //var q = _storeDbContext.Product.AsNoTracking().ToListAsync();
            using (_dbContext)
            {
                try
                {
                    var q = await _dbContext.Product.ToListAsync();
                    return q;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _dbContext?.Dispose();
                }

            }


        }

        public async Task<Product> FindByIdAsync(int id)
        {
            try
            {
                var q = await _dbContext.Product.FindAsync(id);
                return q;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _dbContext?.Dispose();
            }

        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
