using EVENTURES.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EVENTURES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EVENTURES.App.Middleweares
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IServiceProvider provider;

        public SeedDataMiddleware(RequestDelegate next, IServiceProvider provider)
        {
            this.next = next;
            this.provider = provider;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)//, EventureDbContext dbContextt)
        {
            var dbContext = provider.GetService<EventureDbContext>();

            if (!dbContext.Events.Any())
            {
                this.SeedEvents(dbContext);
            }

            if (!dbContext.Roles.Any())
            {
                this.SeedRoles(this.provider);
            }

            await this.next(context);
        }

        private void SeedEvents(EventureDbContext context)
        {
            var sampleEvents = new List<Event>();
            for (int i = 0; i < 10; i++)
            {
                var eventt = new Event()
                {
                    Name = $"Event {i}",
                    Place = $"Place {i}",
                    Start = DateTime.Now.Add(TimeSpan.FromDays(i)),
                    End = DateTime.Now.Add(TimeSpan.FromDays(i * 2)),
                    PricePerTicket = 10 * i,
                    TotalTickets = 100 * i
                };

                context.Events.Add(eventt);
            }

            context.SaveChanges();
        }

        public void SeedRoles(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Administrator").Result;

            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Administrator")).GetAwaiter();
                //roleManager.SetRoleNameAsync(new IdentityRole(), "Administrator");
            }
        }
    }
}
