using PetHome.Entities;

namespace PetHome.Repositories;

public interface IPetsRepository
{
    void AddPet(PetEntity pet);
    PetEntity GetPet(Guid id);
    IEnumerable<PetEntity> GetPets();
}