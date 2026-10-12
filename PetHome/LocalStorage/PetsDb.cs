using PetHome.Dto;

namespace PetHome.LocalStorage;

public static class PetsDb
{
    public static List<Pet> Pets => new()
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
}