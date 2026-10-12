using Microsoft.AspNetCore.Mvc;
using PetHome.Dto;
using PetHome.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPetService, PetService>();

builder.Services.AddScoped<INotificationSender, SmsSender>();
builder.Services.AddScoped<INotificationSender, EmailSender>();
builder.Services.AddScoped<INotificationSender, TelegramSender>();
builder.Services.AddTransient<ICounterService, CounterService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet(
    "/pets", 
    (IPetService petService, [FromQuery]string? name = null) 
        =>
    {
        return petService.GetPets(name);
    });
app.MapGet(
    "/pets/{id:int}",
    (IPetService petService, [FromRoute]int id) => petService.GetPet(id));
app.MapPost(
    "/pets",
    (IPetService petService, ICounterService counterService, [FromBody]Pet pet) =>
    {
        counterService.Counter++;
        Console.WriteLine($"Start endpoint: {counterService.Counter}");
        petService.CreatePet(pet);
    });

app.Run();