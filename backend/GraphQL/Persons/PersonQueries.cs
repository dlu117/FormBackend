using System.Linq;
using HotChocolate;
using backend.Data;
using backend.Model;
using HotChocolate.Types;
using backend.Extensions;

namespace backend.GraphQL.Persons
{
    [ExtendObjectType(name: "Query")]
    public class PersonQueries
    {
        public IQueryable<Person> GetPersons([ScopedService] AppDbContext context)
        {
            return context.Persons;
        }

        [UseAppDbContext]
        public Person GetPerson(int id, [ScopedService] AppDbContext context)
        {
            return context.Persons.Find(id);
        }
    }
}