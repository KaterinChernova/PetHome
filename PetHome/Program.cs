using Microsoft.AspNetCore.Mvc;
using PetHome.Dto;
using PetHome.Repositories;
using PetHome.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddSingleton<IPetsRepository, InMemoryPetsRepository>();
builder.Services.AddControllers();

builder.Services.AddScoped<INotificationSender, SmsSender>();
builder.Services.AddScoped<INotificationSender, EmailSender>();
builder.Services.AddScoped<INotificationSender, TelegramSender>();
builder.Services.AddTransient<ICounterService, CounterService>();

var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();