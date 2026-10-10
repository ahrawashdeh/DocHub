using DocumentPlatform.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _documentService;

    public DocumentsController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Document>> Get()
    {
        return Ok(_documentService.GetDocuments());
    }
}
