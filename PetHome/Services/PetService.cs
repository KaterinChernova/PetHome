using PetHome.Dto;
using PetHome.Entities;
using PetHome.Enums;
using PetHome.LocalStorage;
using PetHome.Repositories;

namespace PetHome.Services;

internal class PetService: IPetService
{
    private IPetsRepository _petsRepository;
    
    public PetService(IPetsRepository petsRepository)
    {
        _petsRepository = petsRepository;
    }
    
    public IReadOnlyCollection<PetDto> GetPets()
    {
        return _petsRepository.GetPets()
            .Select(PetDto.From)
            .ToArray();
    }
    
    public PetDto GetPet(Guid id)
    {
       var pet = _petsRepository.GetPet(id);
       return PetDto.From(pet);
    }
    
    public void CreatePet(AddPetRequest addPetRequest)
    {
        _petsRepository.AddPet(new PetEntity()
        {
            Id = Guid.NewGuid(),
            Name = addPetRequest.Name,
            Description = addPetRequest.Description,
            Gender = addPetRequest.Gender,
            Age = addPetRequest.Age,
            Kind = addPetRequest.Kind,
            Breed = addPetRequest.Breed,
            Status = PetStatus.Registered,
            RegisteredDate = DateTimeOffset.UtcNow
        });
    }
}