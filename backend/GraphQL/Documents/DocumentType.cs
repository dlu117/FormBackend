using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using backend.Data;
using backend.Model;
using backend.GraphQL.Persons;
using backend.GraphQL.Comments;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Documents
{
    public class DocumentType : ObjectType<Document>
    {
        protected override void Configure(IObjectTypeDescriptor<Document> descriptor)
        {
            descriptor.Field(p => p.Id).Type<NonNullType<IdType>>();
            descriptor.Field(p => p.Name).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Description).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Link).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Date).Type<NonNullType<EnumType<Date>>>();

            descriptor
                .Field(p => p.Person)
                .ResolveWith<Resolvers>(r => r.GetPerson(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<PersonType>>();

            descriptor
                .Field(p => p.Comments)
                .ResolveWith<Resolvers>(r => r.GetComments(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<ListType<NonNullType<CommentType>>>>();

            descriptor.Field(p => p.Modified).Type<NonNullType<DateTimeType>>();
            descriptor.Field(p => p.Created).Type<NonNullType<DateTimeType>>();

        }


        private class Resolvers
        {
            public async Task<Person> GetPerson(Document document, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Persons.FindAsync(new object[] { document.PersonId }, cancellationToken);
            }

            public async Task<IEnumerable<Comment>> GetComments(Document document, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Comments.Where(c => c.DocumentId == document.Id).ToArrayAsync(cancellationToken);
            }
        }
    }
}

