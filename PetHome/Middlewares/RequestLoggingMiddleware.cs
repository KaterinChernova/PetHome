using System.Diagnostics;
using PetHome.Filters;

namespace PetHome.Middlewares;

public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation(
            "HTTP Request: {0} {1} started at = {2}",
            context.Request.Method,
            context.Request.Path,
            DateTimeOffset.UtcNow);
        
        var started = Stopwatch.GetTimestamp();

        try
        {
            await next(context);
        }
        finally
        {
            var elapsed = Stopwatch.GetElapsedTime(started);
            logger.LogInformation(
                "HTTP Request: {0} {1} finished; elapsed = {2} ms with statusCode = {3}",
                context.Request.Method,
                context.Request.Path,
                elapsed,
                context.Response.StatusCode);
        }
    }
}