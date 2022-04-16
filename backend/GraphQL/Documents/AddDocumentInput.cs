namespace backend.GraphQL.Documents 
{
    public record AddDocumentInput(
        string Name,
        string Description,
        string Link,
        string Year,
        string PersonId);
}