using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using HotChocolate.Types;
using backend.Data;
using backend.Model;
using backend.GraphQL.Documents;
using backend.GraphQL.Comments;

namespace backend.GraphQL.Persons
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor.Field(s => s.Id).Type<NonNullType<IdType>>();
            descriptor.Field(s => s.Title).Type<NonNullType<StringType>>();
            descriptor.Field(s => s.Name).Type<NonNullType<StringType>>();
            descriptor.Field(s => s.ImageURI).Type<NonNullType<StringType>>();

            descriptor
                .Field(s => s.Documents)
                .ResolveWith<Resolvers>(r => r.GetDocuments(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<ListType<NonNullType<DocumentType>>>>();

            descriptor
                .Field(s => s.Comments)
                .ResolveWith<Resolvers>(r => r.GetComments(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<ListType<NonNullType<CommentType>>>>();
        }

        private class Resolvers
        {
            public async Task<IEnumerable<Document>> GetDocuments(Person person, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Documents.Where(c => c.PersonId == person.Id).ToArrayAsync(cancellationToken);
            }

            public async Task<IEnumerable<Comment>> GetComments(Person person, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Comments.Where(c => c.PersonId == person.Id).ToArrayAsync(cancellationToken);
            }
        }
    }
}


