using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using backend.Data;
using backend.Model;
using backend.Extensions;

namespace backendGraphQL.Documents
{
    [ExtendObjectType(name: "Query")]
    public class DocumentQueries
    {
        [UseAppDbContext]
        [UsePaging]
        public IQueryable<Document> GetDocuments([ScopedService] AppDbContext context)
        {
            return context.Documents.OrderBy(c => c.Created);
        }

        [UseAppDbContext]
        public Document GetDocument(int id, [ScopedService] AppDbContext context)
        {
            return context.Documents.Find(id);
        }
    }
}

