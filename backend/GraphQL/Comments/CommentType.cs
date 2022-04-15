using System.Threading.Tasks;
using System.Threading;
using HotChocolate;
using HotChocolate.Types;
using backend.Data;
using backend.Model;
using backend.GraphQL.Documents;

namespace backend.GraphQL.Comments
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Field(s => s.Id).Type<NonNullType<IdType>>();
            descriptor.Field(s => s.Content).Type<NonNullType<StringType>>();

            descriptor
                .Field(s => s.Document)
                .ResolveWith<Resolvers>(r => r.GetDocument(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<CommentType>>();

            descriptor
                .Field(s => s.Person)
                .ResolveWith<Resolvers>(r => r.GetPerson(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<CommentType>>();

            descriptor.Field(p => p.Modified).Type<NonNullType<DateTimeType>>();
            descriptor.Field(p => p.Created).Type<NonNullType<DateTimeType>>();

        }

        private class Resolvers
        {
            public async Task<Document> GetDocument(Comment comment, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Documents.FindAsync(new object[] { comment.PersonId }, cancellationToken);
            }

            public async Task<Person> GetPerson(Comment comment, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Persons.FindAsync(new object[] { comment.PersonId }, cancellationToken);
            }
        }
    }
}

