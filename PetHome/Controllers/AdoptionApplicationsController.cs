using Microsoft.AspNetCore.Mvc;
using PetHome.Dto;
using PetHome.Exceptions;
using PetHome.Filters;
using PetHome.Services;

namespace PetHome.Controllers;

[ApiController]
[Route("adoption-applications")]
public sealed class AdoptionApplicationsController(IAdoptionApplicationService service) : ControllerBase
{
    [HttpPost]
    [ServiceFilter(typeof(AdoptionEnableFilter))]
    public async Task<ActionResult<Guid>> Create(
        AddAdoptionApplicationRequest request,
        CancellationToken cancellationToken)
    {
        var applicationId = await service.Add(request, cancellationToken);

        return new ObjectResult(applicationId)
        {
            StatusCode = StatusCodes.Status201Created
        };
    }

    [HttpGet("created")]
    public async Task<ActionResult<AdoptionApplicationDto>> Get(CancellationToken cancellationToken)
    {
        return new ObjectResult(
            await service.GetCreatedApplications(cancellationToken));
    }
}
