using DocumentPlatform.Api.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DocumentPlatform.Api.Controllers;

[ApiController]
[Route("api/document-options")]
public class DocumentOptionsController : ControllerBase
{
    private readonly DocumentOptions _options;

    public DocumentOptionsController(IOptions<DocumentOptions> options)
    {
        _options = options.Value;
    }

    [HttpGet]
    public ActionResult<DocumentOptions> Get()
    {
        return Ok(_options);
    }
}
