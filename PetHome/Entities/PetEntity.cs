using PetHome.Enums;

namespace PetHome.Entities;

public class PetEntity
{
    public Guid Id { get; set; }
        
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Age { get; set; }
    
    public PetKind Kind { get; set; }
    
    public string Breed { get; set; }
    
    public Gender Gender { get; set; }
    
    public PetStatus Status { get; set; }
    
    public DateTimeOffset RegisteredDate { get; set; }
}