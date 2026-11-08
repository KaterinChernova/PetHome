using PetHome.Dto;

namespace PetHome.Services;

public interface IAdoptionApplicationService
{
    Task<Guid> Add(
        AddAdoptionApplicationRequest  request,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<AdoptionApplicationDto>> GetCreatedApplications(CancellationToken cancellationToken = default);
}