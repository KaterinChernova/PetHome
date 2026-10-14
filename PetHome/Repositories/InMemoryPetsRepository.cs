using System.Collections.Concurrent;
using PetHome.Entities;

namespace PetHome.Repositories;

public class InMemoryPetsRepository : IPetsRepository
{
    private readonly ConcurrentDictionary<Guid, PetEntity> _pets = new();
    
    public void AddPet(PetEntity pet)
    {
        if (!_pets.TryAdd(pet.Id, pet))
        {
            throw new InvalidOperationException(
                $"Pet with id {pet.Id} already exists");
        }
    }

    public PetEntity GetPet(Guid id)
    {
        if(!_pets.TryGetValue(id, out PetEntity? pet))
        {
            throw new InvalidOperationException(
                $"Pet with id {id} does not exist");
        }
        
        return pet;
    }

    public IEnumerable<PetEntity> GetPets()
    {
        return _pets.Values;
    }
}