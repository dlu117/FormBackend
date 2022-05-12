using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using backend.Model;
using backend.Data;
using backend.Extensions;


namespace backend.GraphQL.Documents
{
    [ExtendObjectType(name: "Mutation")]
    public class DocumentMutations
    {
        [UseAppDbContext]
        public async Task<Document> AddDocumentAsync(AddDocumentInput input,
            [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var document = new Document
            {
                Name = input.Name,
                Description = input.Description,
                Link = input.Link,
                Date = (Date)Enum.Parse(typeof(Date), input.Year),
                PersonId = int.Parse(input.PersonId),
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };
            context.Documents.Add(document);

            await context.SaveChangesAsync(cancellationToken);

            return document;
        }

        [UseAppDbContext]
        public async Task<Document> DeleteDocumentAsync(DeleteDocumentInput input,
           [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var document = await context.Documents.FindAsync(int.Parse(input.DocumentId));
            context.Documents.Remove(document);
            await context.SaveChangesAsync(cancellationToken);
            return document;
        }


        [UseAppDbContext]
        public async Task<Document> EditDocumentAsync(EditDocumentInput input,
            [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var document = await context.Documents.FindAsync(int.Parse(input.DocumentId));

            document.Name = input.Name ?? document.Name;
            document.Description = input.Description ?? document.Description;
            document.Link = input.Link ?? document.Link;
            document.Modified = DateTime.Now;

            await context.SaveChangesAsync(cancellationToken);

            return document;
        }
    }
}