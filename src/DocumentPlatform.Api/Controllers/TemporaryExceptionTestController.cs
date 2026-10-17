using Microsoft.AspNetCore.Mvc;

namespace DocumentPlatform.Api.Controllers;

// Temporary diagnostic endpoint. Remove after verifying the exception handler.
[ApiController]
[Route("api/exception-test")]
public class TemporaryExceptionTestController : ControllerBase
{
    private readonly ILogger<TemporaryExceptionTestController> _logger;

    public TemporaryExceptionTestController(ILogger<TemporaryExceptionTestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogWarning("Exception test endpoint invoked; throwing a deliberate exception");

        throw new InvalidOperationException("Temporary exception-handler test.");
    }
}
