using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Domain.Entities;
using StoreDemo.Persistence.DbContexts;

namespace StoreDemo.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product, int>, IProductRepository
{
    public ProductRepository(StoreDemoDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<IReadOnlyList<Product>> GetAllProductsSortedByNameAsync()
    {
        return await _dbContext.Products.Include(p => p.Category).OrderBy(p => p.Name).ToListAsync();
    }
    public async Task<Product> GetProduct(int id)
    {
        return await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
    }
}
