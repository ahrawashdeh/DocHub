namespace DocumentPlatform.Api.Middleware;

public class ShortCircuitMiddleware
{
    private readonly RequestDelegate _next;

    public ShortCircuitMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Equals("/api/documents/blocked", StringComparison.Ordinal))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync(new { message = "Request blocked by middleware" });
            return;
        }

        await _next(context);
    }
}
