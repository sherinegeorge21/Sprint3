using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static dotnet_core_xunit.Dtos.UserDto;

namespace dotnet_core_xunit.Entities.TestDb
{
    public static class DataSeeder
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<TestDbContext>();

                db.Users.AddRange(new Users[]
                {
                    new Users() {Id = 1, FirstName = "Barış Ateş", LastName="",Email = "info@barisates.com", Password = "123"},
                    new Users() {Id = 2, FirstName = "Kemal Akçıl", LastName="George",Email = "me@kemalakcil.com", Password = "675" },
                });

                db.Tasks.AddRange(new Tasks[]
         {
                    new Tasks() {Id = 1, ProjectID = 2, Status=3,AssignedToUserID =1, Detail = "Hello World", CreatedOn=new DateTime(2020,3,3)},
                    new Tasks() {Id = 2, ProjectID = 3, Status=2,AssignedToUserID =2, Detail = "Fibonacci", CreatedOn=new DateTime(2021,10,3)},
         });

                db.Projects.AddRange(new Projects[]
{
                    new Projects() {Id = 1, Name="Sherine", Detail = "Hello World", CreatedOn=new DateTime(2020,3,3)},
                    new Projects() {Id = 2, Name="New", Detail = "Fibonacci", CreatedOn=new DateTime(2021,10,3)},
});

                db.SaveChanges();
            }
        }
    }
}
