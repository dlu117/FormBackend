using System.Linq;
using HotChocolate;
using backend.Data;
using backend.Model;
using HotChocolate.Types;

namespace backend.GraphQL.Persons
{
    [ExtendObjectType(name: "Query")]
    public class PersonQueries
    {
        public IQueryable<Person> GetPersons([ScopedService] AppDbContext context)
        {
            return context.Persons;
        }
    }
}