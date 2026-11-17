using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHome.DataBase;
using PetHome.Dto;
using PetHome.Exceptions;
using PetHome.Filters;
using PetHome.Middlewares;
using PetHome.Repositories;
using PetHome.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddSingleton<IPetsRepository, InMemoryPetsRepository>();
builder.Services.AddScoped<IPetsRepository, EfPetsRepository>();
builder.Services.AddScoped<IAdoptionApplicationService, AdoptionApplicationService>();
builder.Services.AddScoped<AdoptionEnableFilter>();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers(options =>
{
    options.Filters.AddService<AdoptionEnableFilter>();
});

builder.Services.AddDbContext<PetHomeDbContext>(opt =>
{
    opt.UseNpgsql("Host=localhost;Port=5432;Username=pethome_app;Password=1234567;Database=pethome")
        .UseLazyLoadingProxies();
});

var app = builder.Build();

app.UseExceptionHandler();
app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();