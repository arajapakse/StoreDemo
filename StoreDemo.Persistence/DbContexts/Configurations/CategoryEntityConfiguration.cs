using StoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StoreDemo.Persistence.DbContexts.Configurations;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Configuring Category entity
        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(510);

        builder
            .Property(c => c.Description)
            .HasMaxLength(1024);
    }
}
