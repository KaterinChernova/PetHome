using PetHome.Dto;

namespace PetHome.Services;

public interface IPetService
{
    Task<IReadOnlyCollection<PetDto>> GetPets();
    Task<PetDto> GetPet(Guid id);
    Task CreatePet(AddPetRequest addPetRequest);
}