using Microsoft.Extensions.DependencyInjection;
using StoreDemo.Application.Features.Products.Commands.CreateProduct;
using StoreDemo.Application.Features.Products.Commands.UpdateProduct;
using StoreDemo.Application.Features.Products.Common;

namespace StoreDemo.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        // validator 
        services.AddScoped<CreateProductCommandValidator>();
        services.AddScoped<UpdateProductCommandValidator>();
        
        return services;
    }
}