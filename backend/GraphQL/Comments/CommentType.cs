/*using System.Threading.Tasks;
using System.Threading;
using HotChocolate;
using HotChocolate.Types;
using backend.Data;
using backend.Model;
using backend.GraphQL.Tasks;

namespace backend.GraphQL.Comments
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Field(s => s.Id).Type<NonNullType<IdType>>();
            descriptor.Field(s => s.Content).Type<NonNullType<StringType>>();

            descriptor
                .Field(s => s.Task)
                .ResolveWith<Resolvers>(r => r.GetProject(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<CommentType>>();

            descriptor
                .Field(s => s.Person)
                .ResolveWith<Resolvers>(r => r.GetStudent(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<CommentType>>();

            descriptor.Field(p => p.Modified).Type<NonNullType<DateTimeType>>();
            descriptor.Field(p => p.Created).Type<NonNullType<DateTimeType>>();

        }

        private class Resolvers
        {
            public async Task<Task> GetTask(Comment comment, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Tasks.FindAsync(new object[] { comment.ProjectId }, cancellationToken);
            }

            public async Task<Student> GetStudent(Comment comment, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Students.FindAsync(new object[] { comment.StudentId }, cancellationToken);
            }
        }
    }
}

*/