using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
               .UseHiLo("catalog_brand_hilo")
               .IsRequired();

            builder.Property(cb => cb.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Ignore(b => b.DomainEvents);
        }
    }
}
