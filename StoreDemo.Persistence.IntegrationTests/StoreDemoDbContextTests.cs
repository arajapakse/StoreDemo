using Microsoft.EntityFrameworkCore; // Ensure this namespace is included
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using Shouldly;
using StoreDemo.Persistence.DbContexts;

namespace StoreDemo.Persistence.IntegrationTests;
public class StoreDemoDbContextTests
{
    public StoreDemoDbContextTests()
    {
        var dbContextOptions = new DbContextOptionsBuilder<StoreDemoDbContext>()
           .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Ensure the extension method is available
           .Options;
    }

}
}
