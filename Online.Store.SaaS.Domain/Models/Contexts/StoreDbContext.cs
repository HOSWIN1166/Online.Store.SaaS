using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online.Store.SaaS.Domain.Models.Domains;
using System.Reflection;

namespace Online.Store.SaaS.Domain.Models.Contexts
{
    public class StoreDbContext : IdentityDbContext<IdentityUser>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Product> Product { get; set; }
    }
}
