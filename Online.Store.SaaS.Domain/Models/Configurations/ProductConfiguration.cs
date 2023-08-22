using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online.Store.SaaS.Domain.Models.Domains;

namespace Online.Store.SaaS.Domain.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
