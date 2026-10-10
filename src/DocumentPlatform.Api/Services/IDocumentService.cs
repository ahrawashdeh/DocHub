namespace DocumentPlatform.Api.Services;

public interface IDocumentService
{
    IEnumerable<Document> GetDocuments();
}
