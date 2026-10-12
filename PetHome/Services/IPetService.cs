using PetHome.Dto;

namespace PetHome.Services;

public interface IPetService
{
    IReadOnlyCollection<Pet> GetPets(string? name);
    Pet GetPet(int id);
    void CreatePet(Pet pet);
}