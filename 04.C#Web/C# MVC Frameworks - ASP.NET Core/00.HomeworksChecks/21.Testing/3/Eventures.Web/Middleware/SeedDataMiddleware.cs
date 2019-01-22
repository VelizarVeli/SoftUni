using Eventures.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using System.Collections.Generic;

namespace Eventures.Web.Middleware
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;
        // private readonly IServiceProvider provider;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
            // this.provider = provider;
        }

        public async Task InvokeAsync(HttpContext context
            , EventuresDbContext dbContext
            , UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.Eventd.Any())
            {
                this.SeedEvents(dbContext);
            }

            if (!dbContext.Roles.Any())
            {
               await this.SeedRoles(userManager, roleManager);
            }

            await this.next(context);
        }

        private void SeedEvents(EventuresDbContext context)
        {
            var sampleEvents = new List<Event>();
            for (int i = 0; i <= 10; i++)
            {
                var sampleEvent = new Event
                {
                    Name = $"Sample event number {i}",
                    Place = $"Sample place address 100{i}",
                    Start = DateTime.Now.Add(TimeSpan.FromDays(i)),
                    End = DateTime.Now.Add(TimeSpan.FromDays(i * 2)),
                    PricePerTicket = 10 + i,
                    TotalTickets = i * 100
                };
                context.Eventd.Add(sampleEvent);
            }
            context.SaveChanges();
        }

        private async Task SeedRoles(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (result.Succeeded && userManager.Users.Any())
            {
                var firstUser = userManager.Users.FirstOrDefault();
                await userManager.AddToRoleAsync(firstUser, "Admin");
            }
        }
    }
}
