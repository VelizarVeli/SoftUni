using Eventures.Data;
using Eventures.Models;
using Eventures.Services;
using Eventures.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Eventures.Tests
{
    public class EventsServiceTests
    {
        public EventsServiceTests()
        {
            this.Options = new DbContextOptionsBuilder<EventuresDbContext>()
                        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .Options;
        }

        public DbContextOptions<EventuresDbContext> Options { get; }

        [Fact]
        public async Task CreateMethod_ShouldAddEventToContext()
        {
            var context = new EventuresDbContext(this.Options);

            var eventService = new EventsService(context);
            await eventService.CreateAsync("Name", DateTime.UtcNow, DateTime.UtcNow.AddDays(3), "Place", 100, 10.00m);

            Assert.Equal(1, context.Eventd.Count());
        }

        [Fact]
        public void All_ShouldGetAllEvents()
        {
            var dbContext = new EventuresDbContext(this.Options);

            dbContext.Eventd.AddRange(this.TestEvents().AsQueryable());
            dbContext.SaveChanges();

            EventsService eventsService = new EventsService(dbContext);

            var events = eventsService.AllByStart();

            Assert.True(events.Count() == 3);
        }

        [Fact]
        public void GetById_ShouldReturnCorrectEventById()
        {
            var dbContext = new EventuresDbContext(this.Options);

            var @event = new Event
            {
                Id = "10",
                Name = "FootballGame",
                PricePerTicket = 20.00m,
                Place = "Place",
                TotalTickets = 1500,
                Start = new DateTime(2018, 12, 23, 19, 30, 0),
                End = new DateTime(2018, 12, 23, 21, 0, 0)
            };

            dbContext.Eventd.AddRange(this.TestEvents().AsQueryable());
            dbContext.Eventd.Add(@event);
            dbContext.SaveChanges();

            Assert.True(dbContext.Eventd.Count() == 4);

            var eventSerivce = new EventsService(dbContext);
            var dbEvent = eventSerivce.GetById("10");

            Assert.True(dbEvent.Name == "FootballGame");
        }

        
        public List<Event> TestEvents()
        {
            return new List<Event>
            {
                new Event
                {
                      Id = "1",
                    Name = "FootballGame",
                    PricePerTicket = 10.25m,
                    Place = "Somewhere",
                    TotalTickets = 15000,
                    Start = new DateTime(2018, 12, 23, 19, 30, 0),
                    End = new DateTime(2018, 12, 23, 21, 0, 0)
                },
                new Event
                {
                      Id = "2",
                    Name = "BaseballGame",
                    PricePerTicket = 12.25m,
                    Place = "Nowhere",
                    TotalTickets = 20000,
                    Start = new DateTime(2019, 1, 15, 15, 0, 0),
                    End = new DateTime(2018, 1, 15, 16, 30, 0)
                },
                new Event
                {
                    Id = "3",
                    Name = "MMA Fight",
                    PricePerTicket = 15,
                    Place = "UFC",
                    TotalTickets = 0,
                    Start = new DateTime(2018, 12, 23, 19, 30, 0),
                    End = new DateTime(2018, 12, 23, 21, 0, 0)
                }
            };
        }
    }
}
