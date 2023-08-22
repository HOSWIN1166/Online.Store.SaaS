using Online.Store.SaaS.Domain.Models.Domains;

namespace Online.Store.SaaS.Domain.Models.Contracts
{
    public interface IProductRepository
    {
        Task InsertAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(Product entity);
        Task<List<Product>> Select();
        Task<Product> FindByIdAsync(int id);
        Task SaveChanges();
    }
}
