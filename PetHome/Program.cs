using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var pets = new List<Pet>()
{
    new()
    {
        Name = "Барсик",
        Type = "Cat",
        Age = 10
    },
    new()
    {
        Name = "Мурзик",
        Type = "Cat",
        Age = 1
    },
    new()
    {
        Name = "Тошка",
        Type = "Dog",
        Age = 5
    },
    new()
    {
        Name = "Мурзик",
        Type = "Dog",
        Age = 11
    }
};

app.MapGet("/", () => "Hello World!");
app.MapGet("/pets", ([FromQuery]string? name = null) =>
{
    if(!string.IsNullOrEmpty(name))
        return pets.Where(pet => pet.Name == name);
    
    return pets;
});
app.MapGet("/pets/{id:int}", ([FromRoute]int id) =>
{
    if (id >= pets.Count || id < 0)
        return Results.BadRequest(new
        {
            Code = "parameter_format",
            Message = $"Неправильный id. Id доложен быть от 0 до {pets.Count - 1}"
        });
    
    return Results.Ok(pets[id]);
});
app.MapPost("/pets", ([FromBody]Pet pet) => pets.Add(pet));

app.Run();

public class Pet
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Age { get; set; }
}