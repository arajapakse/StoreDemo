
using StoreDemo.Domain.Entities;

namespace StoreDemo.Application.Contracts.Persistence;


public interface IProductRepository : IAsyncRepository<Product, int>
{
    Task<IReadOnlyList<Product>> GetAllProductsSortedByNameAsync();
}
