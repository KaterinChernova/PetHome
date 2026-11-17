using System.Diagnostics;

namespace PetHome.Middlewares;

public class RequestLoggingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine(
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
            Console.WriteLine(
                "HTTP Request: {0} {1} finished; elapsed = {2} ms with statusCode = {3}",
                context.Request.Method,
                context.Request.Path,
                elapsed,
                context.Response.StatusCode);
        }
    }
}