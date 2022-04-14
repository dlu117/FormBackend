/*using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using HotChocolate.Types;
using backend.Data;
using backend.Model;
using backend.GraphQL.Tasks;
using backend.GraphQL.Comments;

namespace backend.GraphQL.Persons
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor.Field(s => s.Id).Type<NonNullType<IdType>>();
            descriptor.Field(s => s.Tasks).Type<NonNullType<StringType>>();
            descriptor.Field(s => s.Name).Type<NonNullType<StringType>>();
            descriptor.Field(s => s.ImageURI).Type<NonNullType<StringType>>();

            descriptor
                .Field(s => s.Tasks)
                .ResolveWith<Resolvers>(r => r.GetTasks(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<ListType<NonNullType<TaskType>>>>();

            descriptor
                .Field(s => s.Comments)
                .ResolveWith<Resolvers>(r => r.GetComments(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<ListType<NonNullType<CommentType>>>>();
        }

        private class Resolvers
        {
            public async Task<IEnumerable<Model.Task>> GetTasks(Person person, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Tasks.Where(c => c.PersonId == person.Id).ToArrayAsync(cancellationToken);
            }

            public async Task<IEnumerable<Comment>> GetComments(Person person, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Comments.Where(c => c.PersonId == person.Id).ToArrayAsync(cancellationToken);
            }
        }
    }
}

*/