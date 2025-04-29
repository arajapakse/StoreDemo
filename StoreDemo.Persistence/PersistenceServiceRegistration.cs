using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Persistence.DbContexts;
using StoreDemo.Persistence.Repositories;

namespace StoreDemo.Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StoreDemoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("StoreDemoConnectionString")));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
