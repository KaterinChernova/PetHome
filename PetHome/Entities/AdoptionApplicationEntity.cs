using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetHome.Enums;

namespace PetHome.Entities;

public class AdoptionApplicationEntity
{
    public Guid Id { get; set; }
    
    public Guid PetId { get; set; }
    public virtual PetEntity Pet { get; set; }
    
    public Guid UserId { get; set; }
    public virtual UserEntity User { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public ApplicationStatus Status { get; set; }
}