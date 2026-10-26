using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetHome.Enums;

namespace PetHome.Entities;

[Table("pets")]
public class PetEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
        
    [Required]
    [MaxLength(100)]
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(1000)]
    [Column("description", TypeName = "varchar(1000)")]
    public string Description { get; set; }
    
    [Required]
    [Range(0, 100)]
    [Column("age", TypeName = "integer")]
    public int Age { get; set; }
    
    [Required]
    [Column("kind", TypeName = "integer")]
    public PetKind Kind { get; set; }
    
    [Required]
    [MaxLength(200)]
    [Column("breed", TypeName = "varchar(200)")]
    public string Breed { get; set; }
    
    [Required]
    [Column("gender", TypeName = "integer")]
    public Gender Gender { get; set; }
    
    [Required]
    [Column("status", TypeName = "integer")]
    public PetStatus Status { get; set; }
    
    [Required]
    [Column("registered_date", TypeName = "date")]
    public DateTime RegisteredDate { get; set; }
}