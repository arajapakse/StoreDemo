using Microsoft.EntityFrameworkCore;
using StoreDemo.Domain.Entities;

namespace StoreDemo.Persistence.DbContexts;

public class StoreDemoDbContext : DbContext
{
    public StoreDemoDbContext(DbContextOptions<StoreDemoDbContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDemoDbContext).Assembly);

        StoreDemoTestData.SeedData(modelBuilder);
    }
    
}

