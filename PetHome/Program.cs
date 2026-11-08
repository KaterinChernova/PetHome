using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHome.DataBase;
using PetHome.Dto;
using PetHome.Repositories;
using PetHome.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddSingleton<IPetsRepository, InMemoryPetsRepository>();
builder.Services.AddScoped<IPetsRepository, EfPetsRepository>();
builder.Services.AddScoped<IAdoptionApplicationService, AdoptionApplicationService>();
builder.Services.AddControllers();

builder.Services.AddDbContext<PetHomeDbContext>(opt =>
{
    opt.UseNpgsql("Host=localhost;Port=5432;Username=pethome_app;Password=1234567;Database=pethome")
        .UseLazyLoadingProxies();
});

var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();