using System;
using Cities.Models;
using Microsoft.EntityFrameworkCore;

namespace Cities.Data
{
    public class PersonsContext : DbContext
    {
        public PersonsContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder) {

            base.OnModelCreating(builder);
        }

        public DbSet<Person> Persons { get; set; }


    }
}
