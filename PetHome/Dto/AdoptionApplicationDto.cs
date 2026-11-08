using PetHome.Enums;

namespace PetHome.Dto;

public record AdoptionApplicationDto(
           Guid Id,
           Guid PetId,
           string PetName,
           Guid ApplicantId,
           string ApplicantDisplayName,
           string ContactName,
           string? Comment,
           ApplicationStatus Status,
           DateTimeOffset CreatedAtUtc);