using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PetHome.Exceptions;

public class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
            return false;
        
        var problemDetails = new ProblemDetails()
        {
            Status = 409,
            Title = "Ошибка валидации данных",
            Detail = $"{validationException.Code} - {validationException.Message}"
        };

        httpContext.Response.StatusCode = problemDetails.Status!.Value;
        
        var writer = httpContext.RequestServices.GetRequiredService<IProblemDetailsService>();
        if (!await writer.TryWriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                ProblemDetails = problemDetails
            }))
        {
            await httpContext.Response.WriteAsJsonAsync(problemDetails,
                options: null,
                contentType: "application/problem+json",
                cancellationToken: cancellationToken);
        }

        return true;
    }
}