using Microsoft.EntityFrameworkCore;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Persistence.DbContexts;

namespace StoreDemo.Persistence.Repositories;

public abstract class BaseRepository<TEntity, TId> : IAsyncRepository<TEntity, TId> where TEntity : class
{
    protected readonly StoreDemoDbContext _dbContext;

    public BaseRepository(StoreDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async virtual Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async virtual Task DeleteAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async virtual Task<TEntity> GetByIdAsync(TId id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async virtual Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async virtual Task UpdateAsync(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
