namespace StoreDemo.Application.Contracts.Persistence;

public interface IAsyncRepository<TEntity, TId> where TEntity : class
{
    Task<TEntity> GetByIdAsync(TId id);
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
