using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using PetHome;
using PetHome.DataBase;
using PetHome.Exceptions;
using PetHome.Filters;
using PetHome.Middlewares;
using PetHome.Options;
using PetHome.Repositories;
using PetHome.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddSingleton<IPetsRepository, InMemoryPetsRepository>();
builder.Services.AddScoped<IPetsRepository, EfPetsRepository>();
builder.Services.AddScoped<IAdoptionApplicationService, AdoptionApplicationService>();
builder.Services.AddScoped<AdoptionEnableFilter>();
builder.Services.AddScoped<RequestLoggingMiddleware>();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers(options =>
{
    options.Filters.AddService<AdoptionEnableFilter>();
});

builder.Services.AddOptions<AdoptionApplicationOptions>()
    .Bind(builder.Configuration.GetSection(AdoptionApplicationOptions.SectionName))
    .ValidateDataAnnotations()
    .Validate(options =>
    {
        if (options.Env == "default")
        {
            return false;
        }
        
        return true;
    }, "Value of Env in AdoptionApplicationOptions could not be 'default'.")
    .ValidateOnStart();

builder.Services.AddOptions<PostgreSqlOptions>()
    .Bind(builder.Configuration.GetSection(PostgreSqlOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddSingleton<NpgsqlDataSource>(serviceProvider =>
{
    var options = serviceProvider.GetRequiredService<IOptions<PostgreSqlOptions>>();
    var dataSourceBuilder = new NpgsqlDataSourceBuilder();

    var connection = dataSourceBuilder.ConnectionStringBuilder;

    connection.Host = options.Value.Host;
    connection.Port = options.Value.Port;
    connection.Database = options.Value.Database;
    connection.Username = options.Value.Username;
    connection.Password = options.Value.Password;

    return dataSourceBuilder.Build();
});

builder.Services.AddDbContext<PetHomeDbContext>((serviceProvider, options) =>
{
    var dataSource = serviceProvider.GetRequiredService<NpgsqlDataSource>();
    options.UseNpgsql(dataSource.ConnectionString);
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.UseExceptionHandler();
app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();