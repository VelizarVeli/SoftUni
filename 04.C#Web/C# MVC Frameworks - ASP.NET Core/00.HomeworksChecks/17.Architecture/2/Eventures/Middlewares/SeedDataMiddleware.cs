namespace Eventures.Middlewares
{
    using Eventures.Data;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Eventures.Models;
    using Microsoft.AspNetCore.Identity;

    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            ApplicationDbContext dbContext,
            UserManager<EventuresUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.Events.Any())
            {
                this.SeedEvents(dbContext);
            }

            if (!dbContext.Roles.Any())
            {
              await  this.SeedRoles(userManager, roleManager);
            }

            var firstUser = userManager.Users.FirstOrDefault();
            var admin = userManager.Users.FirstOrDefault(x => x.UserName == "Jordan");
            await userManager.RemoveFromRoleAsync(firstUser, "Administrator");
            await userManager.AddToRoleAsync(admin, "Administrator");
            await this.next(context);
        }

        private async Task SeedRoles(UserManager<EventuresUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Administrator"));

            if (result.Succeeded && userManager.Users.Any())
            {
                var firstUser = userManager.Users.FirstOrDefault();
               await userManager.AddToRoleAsync(firstUser, "Administrator");

            }
        }

        private void SeedEvents(ApplicationDbContext dbContext)
        {
            var sampleEvents = new List<Event>();
            for (int i = 1; i <= 10; i++)
            {
                var sampleEvent = new Event
                {
                    Name = $"Sample event number {i}",
                    Place = $"Sample Place addres 00{i}",
                    Start = DateTime.Now.Add(TimeSpan.FromDays(i)),
                    End = DateTime.Now.Add(TimeSpan.FromDays(i * 2)),
                    PricePerTicket = 10 + i,
                    TotalTickets = 100 * i
                };
                dbContext.Events.Add(sampleEvent);
            }
            dbContext.SaveChanges();
        }
    }
}
