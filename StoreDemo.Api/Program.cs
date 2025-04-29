using StoreDemo.Api;
using Serilog;

Log.Logger = new LoggerConfiguration().
    WriteTo.Console()
    .CreateLogger();

Log.Information("Starting up");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (context, services, configuraiton) => configuraiton
       .ReadFrom.Configuration(context.Configuration)
       .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console(),
    writeToProviders: true
    );

var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

app.Run();
