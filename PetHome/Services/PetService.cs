using Microsoft.EntityFrameworkCore;
using PetHome.Dto;
using PetHome.Entities;
using PetHome.Enums;
using PetHome.LocalStorage;
using PetHome.Repositories;

namespace PetHome.Services;

internal class PetService: IPetService
{
    private readonly IPetsRepository _petsRepository;
    
    public PetService(IPetsRepository petsRepository)
    {
        _petsRepository = petsRepository;
    }
    
    public async Task<IReadOnlyCollection<PetDto>> GetPets()
    {
        return (await _petsRepository.GetPetsAsync())
            .Select(PetDto.From)
            .ToArray();
    }
    
    public async Task<PetDto> GetPet(Guid id)
    {
       var pet = await _petsRepository.GetPetAsync(id);
       return PetDto.From(pet);
    }
    
    public async Task CreatePet(AddPetRequest addPetRequest)
    {
        await _petsRepository.AddPetAsync(new PetEntity()
        {
            Id = Guid.NewGuid(),
            Name = addPetRequest.Name,
            Description = addPetRequest.Description,
            Gender = addPetRequest.Gender,
            DateOfBirthUtc = DateTimeOffset.UtcNow.AddYears(-addPetRequest.Age),
            Kind = addPetRequest.Kind,
            Breed = addPetRequest.Breed,
            Status = PetStatus.Registered,
            RegisteredDateUtc = DateTimeOffset.UtcNow
        });
    }
}