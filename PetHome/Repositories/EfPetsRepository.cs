using Microsoft.EntityFrameworkCore;
using PetHome.DataBase;
using PetHome.Entities;

namespace PetHome.Repositories;

public class EfPetsRepository : IPetsRepository
{
    private readonly PetHomeDbContext context;

    public EfPetsRepository(PetHomeDbContext context)
    {
        this.context = context;
    }

    public void AddPet(PetEntity pet)
    {
        throw new NotImplementedException();
    }

    public PetEntity GetPet(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PetEntity> GetPets()
    {
        return context.Pets
            .AsNoTracking();
    }

    public async Task AddPetAsync(PetEntity pet)
    {
        context.Pets.Add(pet);
        
        await context.SaveChangesAsync();
    }

    public async Task<PetEntity> GetPetAsync(Guid id)
    {
        var pet = await context.Pets.FindAsync(id);
        
        if(pet == null)
            throw new Exception("Pet not found");
        
        return pet;
    }

    public async Task<IEnumerable<PetEntity>> GetPetsAsync()
    {
        return await context.Pets
            .AsNoTracking()
            .ToArrayAsync();
    }
}