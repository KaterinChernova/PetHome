using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PetHome.Filters;

public class AdoptionEnableFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Console.WriteLine("Enter AdoptionEnableFilter");
        var rndValue = Random.Shared.Next(0, 2);
        if (rndValue == 0)
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
            
            Console.WriteLine("Exit AdoptionEnableFilter - adoption creation disable");
            return;
        }
        
        await next();
        
        Console.WriteLine("Exit AdoptionEnableFilter - adoption creation enable");
    }
}