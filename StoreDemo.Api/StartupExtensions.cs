using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreDemo.Api.Middleware;
using StoreDemo.Application;
using StoreDemo.Identity;
using StoreDemo.Identity.Models;
using StoreDemo.Persistence;
using System.Security.Claims;

namespace StoreDemo.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add dependent proejct configurations
        builder.Services.AddApplicationServices();
        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddIdentityServices(builder.Configuration);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.MapIdentityApi<PortalUser>();
           
        app.MapPost("/Logout", async (ClaimsPrincipal user, SignInManager<PortalUser> SignInManager) =>
        {
            await SignInManager.SignOutAsync();
            return Results.Ok();
        });


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCustomExceptionHandler();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
