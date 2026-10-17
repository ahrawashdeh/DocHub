using DocumentPlatform.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _documentService;
    private readonly ILogger<DocumentsController> _logger;

    public DocumentsController(IDocumentService documentService, ILogger<DocumentsController> logger)
    {
        _documentService = documentService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Document>> Get()
    {
        _logger.LogInformation("Retrieving document list");

        return Ok(_documentService.GetDocuments());
    }
}
