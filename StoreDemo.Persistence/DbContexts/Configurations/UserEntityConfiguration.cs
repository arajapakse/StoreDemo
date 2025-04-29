using StoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StoreDemo.Persistence.DbContexts.Configurations;
public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Configuring User entity
        builder
            .Property(u => u.EmailAddress)
            .IsRequired()
            .HasMaxLength(255);

        builder
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(50);
    }
}


