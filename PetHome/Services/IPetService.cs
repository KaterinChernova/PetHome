using PetHome.Dto;

namespace PetHome.Services;

public interface IPetService
{
    IReadOnlyCollection<PetDto> GetPets();
    PetDto GetPet(Guid id);
    void CreatePet(AddPetRequest addPetRequest);
}