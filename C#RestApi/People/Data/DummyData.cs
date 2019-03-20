using System;
using Cities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Cities.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<PersonsContext>();
                context.Database.EnsureCreated();


                if (context.Persons.Local.Count>0)
                {
                    return;   // DB has been seeded
                }

                context.Persons.AddRange(
                    new Person
                    {
                        FirstName = "Monsen",
                        LastName = "Horde",
                        SocialNumber = 294949494
                    },

                    new Person
                    {
                        FirstName = "Jachy",
                        LastName = "Horde",
                        SocialNumber = 294949494
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
