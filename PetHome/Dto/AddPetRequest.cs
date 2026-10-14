using System.ComponentModel.DataAnnotations;
using PetHome.Enums;

namespace PetHome.Dto;

public class AddPetRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [MaxLength(1000)]
    public string Description { get; set; }
    
    [Required]
    [Range(0, 100)]
    public int Age { get; set; }
    
    [Required]
    public PetKind Kind { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Breed { get; set; }
    
    [Required]
    public Gender Gender { get; set; }
}