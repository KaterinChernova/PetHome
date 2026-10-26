using PetHome.Entities;

namespace PetHome.Repositories;

public interface IPetsRepository
{
    void AddPet(PetEntity pet);
    PetEntity GetPet(Guid id);
    IEnumerable<PetEntity> GetPets();
    
    Task AddPetAsync(PetEntity pet);
    Task<PetEntity> GetPetAsync(Guid id);
    Task<IEnumerable<PetEntity>> GetPetsAsync();
}