namespace MSAYearbook.GraphQL.Comments
{
    public record AddCommentInput(
        string Content,
        string DocumentId,
        string PersonId);
}