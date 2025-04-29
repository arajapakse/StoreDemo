using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreDemo.Identity.Models;

namespace StoreDemo.Identity;

public static class IdentityServiceExtensions
{
    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

        services.AddAuthorizationBuilder();

        services.AddDbContext<StoreDemoIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("StoreDemoIdentityConnectionString")));

        services.AddIdentityCore<PortalUser>()
            .AddEntityFrameworkStores<StoreDemoIdentityDbContext>()
            .AddApiEndpoints();
    }
}
