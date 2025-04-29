using StoreDemo.Domain.Entities;

namespace StoreDemo.Application.Contracts.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category, int>
{
}