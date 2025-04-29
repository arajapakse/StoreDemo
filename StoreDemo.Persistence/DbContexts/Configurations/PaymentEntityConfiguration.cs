using StoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StoreDemo.Persistence.DbContexts.Configurations;

public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder) =>
        // Configuring Payment entity

        builder
             .Property(p => p.PaymentAmount)
            .HasColumnType("decimal(18,5)");
}
