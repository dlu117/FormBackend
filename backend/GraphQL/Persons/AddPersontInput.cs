
namespace backend.GraphQL.Persons
{
    public record AddPersonInput(
        string Name,
        string Title,
        string? ImageURI);
}