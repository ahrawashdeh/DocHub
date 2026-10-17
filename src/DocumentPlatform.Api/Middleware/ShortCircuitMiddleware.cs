namespace DocumentPlatform.Api.Middleware;

public class ShortCircuitMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ShortCircuitMiddleware> _logger;

    public ShortCircuitMiddleware(RequestDelegate next, ILogger<ShortCircuitMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Equals("/api/documents/blocked", StringComparison.Ordinal))
        {
            _logger.LogWarning(
                "Blocked {Method} {Path} in short-circuit middleware",
                context.Request.Method,
                context.Request.Path);

            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync(new { message = "Request blocked by middleware" });
            return;
        }

        await _next(context);
    }
}
