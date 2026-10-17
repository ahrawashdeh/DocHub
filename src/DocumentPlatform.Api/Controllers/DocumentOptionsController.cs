using DocumentPlatform.Api.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DocumentPlatform.Api.Controllers;

[ApiController]
[Route("api/document-options")]
public class DocumentOptionsController : ControllerBase
{
    private readonly DocumentOptions _options;
    private readonly ILogger<DocumentOptionsController> _logger;

    public DocumentOptionsController(IOptions<DocumentOptions> options, ILogger<DocumentOptionsController> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<DocumentOptions> Get()
    {
        if (_options.DefaultPageSize <= 0 || _options.MaxPageSize <= 0 || _options.DefaultPageSize > _options.MaxPageSize)
        {
            _logger.LogWarning(
                "Document options look misconfigured: DefaultPageSize {DefaultPageSize}, MaxPageSize {MaxPageSize}",
                _options.DefaultPageSize,
                _options.MaxPageSize);
        }

        _logger.LogInformation(
            "Returning document options with DefaultPageSize {DefaultPageSize} and MaxPageSize {MaxPageSize}",
            _options.DefaultPageSize,
            _options.MaxPageSize);

        return Ok(_options);
    }
}
