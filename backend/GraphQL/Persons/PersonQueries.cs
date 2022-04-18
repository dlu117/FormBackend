using backend.Data;
using backend.Extensions;
using backend.Model;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace backend.GraphQL.Persons
{
    [ExtendObjectType(name: "Query")]
    public class PersonQueries
    {
        [UseAppDbContext]
        [UsePaging] // without it no connections can form 
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