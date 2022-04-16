namespace backend.GraphQL.Documents
{
    public record EditDocumentInput(
        string DocumentId,
        string? Name,
        string? Description,
        string? Link);
}