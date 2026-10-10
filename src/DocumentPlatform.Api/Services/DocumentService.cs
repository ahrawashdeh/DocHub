namespace DocumentPlatform.Api.Services;

public class DocumentService : IDocumentService
{
    private static readonly Document[] Documents =
    [
        new(1, "First Document")
    ];

    public IEnumerable<Document> GetDocuments()
    {
        return Documents;
    }
}

public record Document(int Id, string Title);
