using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using backend.Model;
using backend.Data;
using backend.Extensions;

namespace backend.GraphQL.Persons
{
    [ExtendObjectType(name: "Mutation")]
    public class PersonMutations
    {
        [UseAppDbContext]
        public async Task<Person> AddPersonAsync(AddPersonInput input,
        [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Name = input.Name,
                Title = input.Title,
                ImageURI = input.ImageURI,
            };

            context.Persons.Add(person);
            await context.SaveChangesAsync(cancellationToken);

            return person;
        }

        [UseAppDbContext]
        public async Task<Person> DeletePersonAsync(DeletePersonInput input,
       [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var person = await context.Persons.FindAsync(int.Parse(input.PersonId));
            context.Persons.Remove(person);
            await context.SaveChangesAsync(cancellationToken);
            return person;
        }


        [UseAppDbContext]
        public async Task<Person> EditPersonAsync(EditPersonInput input,
                [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var person = await context.Persons.FindAsync(int.Parse(input.PersonId));

            person.Name = input.Name ?? person.Name;
            person.Title = input.Title?? person.Title;
            person.ImageURI = input.ImageURI ?? person.ImageURI;

            await context.SaveChangesAsync(cancellationToken);

            return person;
        }
    }
}

