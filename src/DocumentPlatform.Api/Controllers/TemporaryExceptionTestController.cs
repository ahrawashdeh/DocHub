using Microsoft.AspNetCore.Mvc;

namespace DocumentPlatform.Api.Controllers;

// Temporary diagnostic endpoint. Remove after verifying the exception handler.
[ApiController]
[Route("api/exception-test")]
public class TemporaryExceptionTestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        throw new InvalidOperationException("Temporary exception-handler test.");
    }
}
