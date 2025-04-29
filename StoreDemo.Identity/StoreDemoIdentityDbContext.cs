
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreDemo.Identity.Models;

namespace StoreDemo.Identity;

public class StoreDemoIdentityDbContext : IdentityDbContext<PortalUser>
{
    public StoreDemoIdentityDbContext(DbContextOptions<StoreDemoIdentityDbContext> options) : base(options)
    {
            
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
    .LogTo(Console.WriteLine)
    .EnableSensitiveDataLogging();
}
