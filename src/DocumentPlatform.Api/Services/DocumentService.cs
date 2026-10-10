namespace DocumentPlatform.Api.Services;

public class DocumentService : IDocumentService
{
    private readonly ILogger<DocumentService> _logger;

    private static readonly Document[] Documents =
    [
        new(1, "First Document")
    ];

    public DocumentService(ILogger<DocumentService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Document> GetDocuments()
    {
        _logger.LogInformation("Returned {DocumentCount} documents", Documents.Length);
        return Documents;
    }
}

public record Document(int Id, string Title);
