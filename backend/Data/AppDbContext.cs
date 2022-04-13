using Microsoft.EntityFrameworkCore;
using backend.Model;

namespace backend.Data
{
    public class AppDbContext : DbContext //class extension of Db context
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}

/* 

DbContext associated to a model to:

Write and execute queries
Materialize query results as entity objects
Track changes that are made to those objects
Persist object changes back on the database
Bind objects in memory to UI controls

DbContext is single threaded and will 
not work with multithreaded request 

 */