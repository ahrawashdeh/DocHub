using Microsoft.AspNetCore.Mvc;

namespace DocumentPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private static readonly Document[] Documents =
    [
        new(1, "First Document")
    ];

    [HttpGet]
    public ActionResult<IEnumerable<Document>> Get()
    {
        return Ok(Documents);
    }
}

public record Document(int Id, string Title);
