
using Moq;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Domain.Entities;

namespace StoreDemo.Application.UnitTest.Mocks;
internal class RepositoryMocks
{
    public static Mock<IProductRepository> GetProductRepository()
    {
        var products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Product A", Price = 10.0m },
            new Product { ProductId = 2, Name = "Product B", Price = 20.0m },
            new Product { ProductId = 3, Name = "Product C", Price = 30.0m }
        };

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(repo => repo.GetAllProductsSortedByNameAsync()).ReturnsAsync(products);

        return mockProductRepository;
    }
}
