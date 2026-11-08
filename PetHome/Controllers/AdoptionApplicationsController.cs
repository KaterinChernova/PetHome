using Microsoft.AspNetCore.Mvc;
using PetHome.Dto;
using PetHome.Exceptions;
using PetHome.Services;

namespace PetHome.Controllers;

[ApiController]
[Route("adoption-applications")]
public sealed class AdoptionApplicationsController(IAdoptionApplicationService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        AddAdoptionApplicationRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var applicationId = await service.Add(request, cancellationToken);

            return new ObjectResult(applicationId)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }
        catch (AdoptionException exception)
        {
            var status = exception.Error switch
            {
                AdoptionError.InvalidId => StatusCodes.Status400BadRequest,
                AdoptionError.PetNotFound or AdoptionError.ApplicantNotFound
                    => StatusCodes.Status404NotFound,
                AdoptionError.PetNotAvailable or AdoptionError.ActiveApplicationAlreadyExists
                    => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            var details = new ProblemDetails
            {
                Status = status,
                Title = "Не удалось создать заявку",
                Detail = exception.Message
            };
            details.Extensions["code"] = exception.Error.ToString();

            return new ObjectResult(details)
            {
                StatusCode = status,
                ContentTypes = { "application/problem+json" }
            };
        }
    }

    [HttpGet("created")]
    public async Task<ActionResult<AdoptionApplicationDto>> Get(CancellationToken cancellationToken)
    {
        return new ObjectResult(
            await service.GetCreatedApplications(cancellationToken));
    }
}
