using StoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StoreDemo.Persistence.DbContexts.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Configuring Product entity
        builder
             .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(510);
        
        builder.Property(p => p.Description)
            .HasMaxLength(1024);

        builder
             .Property(p => p.Price)
            .HasColumnType("decimal(18,5)");

        builder
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
    }
}
