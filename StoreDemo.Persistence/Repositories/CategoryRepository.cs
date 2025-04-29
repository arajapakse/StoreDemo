using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Domain.Entities;
using StoreDemo.Persistence.DbContexts;

namespace StoreDemo.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
{
    public CategoryRepository(StoreDemoDbContext dbContext) : base(dbContext)
    {

    }

}