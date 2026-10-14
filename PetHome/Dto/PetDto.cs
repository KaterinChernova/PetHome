using PetHome.Entities;
using PetHome.Enums;

namespace PetHome.Dto;

public class PetDto
{
    public Guid Id { get; set; }
        
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Age { get; set; }
    
    public PetKind Kind { get; set; }
    
    public string Breed { get; set; }
    
    public Gender Gender { get; set; }
    
    public PetStatus Status { get; set; }

    public static PetDto From(PetEntity pet) =>
        new()
        {
            Id = pet.Id,
            Name = pet.Name,
            Description = pet.Description,
            Age = pet.Age,
            Kind = pet.Kind,
            Status = pet.Status,
            Breed = pet.Breed,
            Gender = pet.Gender
        };
}