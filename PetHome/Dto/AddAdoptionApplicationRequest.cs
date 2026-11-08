using System.ComponentModel.DataAnnotations;

namespace PetHome.Dto;

public class AddAdoptionApplicationRequest
{
    [Required]
    public Guid PetId { get; init; }

    [Required]
    public Guid ApplicantId { get; init; }

    [StringLength(100)]
    public string? ContactName { get; init; }

    [StringLength(254), EmailAddress]
    public string? ContactEmail { get; init; }

    [StringLength(30),  Phone]
    public string? ContactPhone { get; init; }

    [StringLength(1000)]
    public string? Comment { get; init; }
}