using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
               .UseHiLo("category_hilo")
               .IsRequired();

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Ignore(c => c.DomainEvents);
        }
    }
}
