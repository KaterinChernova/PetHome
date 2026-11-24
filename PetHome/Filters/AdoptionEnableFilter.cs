using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using PetHome.Options;

namespace PetHome.Filters;

public class AdoptionEnableFilter : IAsyncActionFilter
{
    private readonly IOptionsMonitor<AdoptionApplicationOptions> _adoptionOptions;
    private readonly ILogger<AdoptionEnableFilter> _logger;

    public AdoptionEnableFilter(IOptionsMonitor<AdoptionApplicationOptions> adoptionOptions, ILogger<AdoptionEnableFilter> logger)
    {
        _adoptionOptions = adoptionOptions;
        _logger = logger;
        _adoptionOptions.OnChange((options) =>
        {
            _logger.LogInformation("AdoptionApplicationOptions were changed");
        });
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _logger.LogInformation("Enter AdoptionEnableFilter");
        
        _logger.LogInformation($"isApplicationEnable = {_adoptionOptions.CurrentValue.IsApplicationEnable}; config env: {_adoptionOptions.CurrentValue.Env}");
        if (!_adoptionOptions.CurrentValue.IsApplicationEnable)
        {
            var problem = new ProblemDetails
            {
                Status = StatusCodes.Status503ServiceUnavailable,
                Title = "Сервис заявок недоступен. Все животные на мед осмотре",
                Detail = "Дата завершения мед осмотра 1 декабря 2026 года"
            };

            context.Result = new ObjectResult(problem)
            {
                StatusCode = problem.Status,
                ContentTypes = { "application/problem+json" }
            };
            
            _logger.LogInformation("Exit AdoptionEnableFilter - adoption creation disable");
            return;
        }
        
        await next();
        
        _logger.LogInformation("Exit AdoptionEnableFilter - adoption creation enable");
    }
}