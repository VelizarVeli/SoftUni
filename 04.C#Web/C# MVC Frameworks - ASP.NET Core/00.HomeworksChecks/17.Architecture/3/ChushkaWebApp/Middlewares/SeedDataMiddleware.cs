namespace EventWebApp.Middlewares
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore.Internal;

    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ApplicationDbContext dbContext)
        {
            if (!dbContext.Events.Any())
            {
                this.SeedEvents(dbContext);
            }

            await this.next(httpContext);
        }

        private void SeedEvents(ApplicationDbContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                var sampleEvent = new Event()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Sample event number {i}",
                    Place = $"Sample place {i}",
                    Start = DateTime.Now.Add(TimeSpan.FromDays(i)),
                    End = DateTime.Now.Add(TimeSpan.FromDays(i * 2)),
                    PricePerTicket = 5 * i,
                    TotalTickets = i * 50
                };

                db.Events.Add(sampleEvent);
            }

            db.SaveChanges();
        }
    }
}

