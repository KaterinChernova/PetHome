using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHome.Entities;

[Table("users")]
public class UserEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}