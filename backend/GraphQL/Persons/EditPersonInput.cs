
namespace backend.GraphQL.Persons
{
    public record EditPersonInput(
        string PersonId,
        string? Name,
        string? Title,
        string? ImageURI);
}