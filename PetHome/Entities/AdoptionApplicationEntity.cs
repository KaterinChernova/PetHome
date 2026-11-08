using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetHome.Enums;

namespace PetHome.Entities;

public class AdoptionApplicationEntity
{
    public Guid Id { get; set; }
    
    public Guid PetId { get; set; }
    public virtual PetEntity Pet { get; set; }
    
    public Guid ApplicantId { get; set; }
    public virtual UserEntity Applicant { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? Comment { get; set; }
    
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }
    public ApplicationStatus Status { get; set; }

    public Guid? DecidedByUserId { get; set; }
    public virtual UserEntity? DecidedByUser { get; set; }
    public DateTimeOffset? DecidedAt { get; set; }
    public string? DecisionComment { get; set; }
    public DateTimeOffset? ClosedAtUtc { get; set; }
}