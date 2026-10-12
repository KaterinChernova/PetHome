using PetHome.Dto;
using PetHome.LocalStorage;

namespace PetHome.Services;

internal class PetService: IPetService
{
    private readonly IEnumerable<INotificationSender> _notificationSenders;
    private readonly ICounterService _counterService;

    public PetService(
        IEnumerable<INotificationSender> notificationSenders,
        ICounterService counterService)
    {
        _notificationSenders = notificationSenders;
        _counterService = counterService;
    }
    
    public IReadOnlyCollection<Pet> GetPets(string? name)
    {
        if(!string.IsNullOrEmpty(name))
            return PetsDb.Pets.Where(pet => pet.Name == name).ToArray();
    
        return PetsDb.Pets;
    }
    
    public Pet GetPet(int id)
    {
        if (id >= PetsDb.Pets.Count || id < 0)
            throw new ArgumentOutOfRangeException("id not found");
    
        return PetsDb.Pets[id];
    }
    
    public void CreatePet(Pet pet)
    {
        _counterService.Counter++;
        Console.WriteLine($"PetService: {_counterService.Counter}");
        
        PetsDb.Pets.Add(pet);
        foreach (var notificationSender in _notificationSenders)
        {
            notificationSender.Send("New Pet created");
        }
    }
}