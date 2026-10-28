using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetHome.Enums;

namespace PetHome.Entities;

[Table("pets")]
public class PetEntity
{
    public Guid Id { get; set; }
        
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public PetKind Kind { get; set; }
    
    public string Breed { get; set; }
    
    public Gender Gender { get; set; }
    
    public PetStatus Status { get; set; }
    
    public DateTime RegisteredDate { get; set; }
    
    public ICollection<AdoptionApplicationEntity> AdoptionApplications { get; set; } 
        = new List<AdoptionApplicationEntity>(); 
}