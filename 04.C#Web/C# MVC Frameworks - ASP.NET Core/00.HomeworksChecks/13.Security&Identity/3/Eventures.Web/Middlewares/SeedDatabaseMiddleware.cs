using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using Eventures.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.Web.Middlewares
{
    public class SeedDatabaseMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDatabaseMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext
            , UserManager<EventureUser> userManager, RoleManager<IdentityRole> roleManager)
        {           
            if (!dbContext.Events.Any())
            {
                this.SeedEvents(dbContext);
            }

            if (!dbContext.Roles.Any())
            {
                this.SeedRoles(roleManager);
            }

            if (!dbContext.Users.Any())
            {
                this.SeedUsers(userManager);
            }
            await this.next(context);
        }

        private void SeedUsers(UserManager<EventureUser> userManager)
        {
            var user = new EventureUser()
            {
                Email = "seededUser@email.com",
                FirstName = "Seeded Admin",
                LastName = "Seeded Admin",
                UserName = "matrix4077",
                Ucn = "seededUcn"
            };

            var result = userManager.CreateAsync(user, "123").Result;

            if (userManager.Users.Count() == 1)
            {
                userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();               
            }
        }

        private void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
            }

            var userRoleExists = roleManager.RoleExistsAsync("User").Result;
            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User")).Wait();
            }
        }

        private void SeedEvents(ApplicationDbContext db)
        {
            var sampleEvent = new List<Event>();
            for (var i = 1; i < 8; i++)
            {
                var ev = new Event()
                {
                    Name = $"Event {i}",
                    Place = $"Sample place {i}",
                    PricePerTicket = 123132,
                    TotalTickets = 100,
                    Start = DateTime.Now.AddDays(i),
                    End = DateTime.Now.AddDays(-i)
                    
                };

                sampleEvent.Add(ev);
            }

            db.Add(sampleEvent);
            db.SaveChanges();
        }
    }
}
