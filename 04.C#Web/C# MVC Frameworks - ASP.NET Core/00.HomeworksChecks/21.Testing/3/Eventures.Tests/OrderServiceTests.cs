using Eventures.Data;
using Eventures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Eventures.Services.Tests
{
    public class OrderServiceTests
    {
        public OrderServiceTests()
        {
            this.Options = new DbContextOptionsBuilder<EventuresDbContext>()
                        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .Options;
        }

        public DbContextOptions<EventuresDbContext> Options { get; }

        [Fact]
        public void CreateOrder_WorkCorrectlyAndSavesItInDb()
        {
            var dbContext = new EventuresDbContext(this.Options);

            var @event = new Event
            {
                Id = "10",
                Name = "FottballGame",
                PricePerTicket = 20.20m,
                Place = "Place",
                TotalTickets = 1500,
                Start = new DateTime(2018, 12, 23, 19, 30, 0),
                End = new DateTime(2018, 12, 23, 21, 0, 0)
            };

            var user = new User
            {
                Id = "11",
                UserName = "Pesho",
                FirstName = "FirstName",
                LastName = "LastName",
                UniqueCitizenNumber = "1234567890",
                Email = "pesho@peshov.bg",
                PasswordHash = "21312312412412"
            };

            dbContext.Eventd.Add(@event);
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var orderService = new OrdersService(dbContext);

            orderService.CreateOrder(@event, user, 5000);

            Assert.True(dbContext.Orders.First().EventureEvent.Name == "FottballGame");
            Assert.True(dbContext.Orders.First().Customer.UserName == "Pesho");
        }

        [Fact]
        public void AllOrders_WorksCorrectly()
        {
            var dbContext = new EventuresDbContext(this.Options);

            dbContext.Orders.AddRange(this.TestData().AsQueryable());
            dbContext.SaveChanges();

            Assert.True(dbContext.Orders.Count() == 3);
            Assert.True(dbContext.Orders.First().EventureEvent.Name == "FootballGame");
            Assert.True(dbContext.Orders.ToList()[1].EventureEvent.Name == "PrivateParty");
            Assert.True(dbContext.Orders.Last().EventureEvent.Name == "New Years Eve");
        }



        private List<Order> TestData()
        {
            return new List<Order>
            {
                new Order
                {
                    OrderedOn = new DateTime(2018, 12, 23, 15, 0, 0),
                    TicketCount = 20,
                    EventureEvent = new Event
                    {
                        Name = "FootballGame",
                        PricePerTicket = 10.25m,
                        Place = "Somewhere",
                        TotalTickets = 15000,
                        Start = new DateTime(2018, 12, 23, 19, 30, 0),
                        End = new DateTime(2018, 12, 23, 21, 0, 0)
                    },
                    Customer = new User
                    {
                        UserName = "Pesho",
                        FirstName = "Peter",
                        LastName = "Petrov",
                        UniqueCitizenNumber = "1234567890",
                        Email = "pesho@pesho.bg",
                        PasswordHash = "21312312412412"
                    }
                },
                new Order
                {
                    OrderedOn = new DateTime(2018, 9, 15, 10, 26, 35),
                    TicketCount = 5,
                    EventureEvent = new Event
                    {
                        Name = "PrivateParty",
                        PricePerTicket = 8,
                        Place = "Lounge",
                        TotalTickets = 100,
                        Start = new DateTime(2018, 9, 20, 20, 0, 0),
                        End = new DateTime(2018, 9, 21, 4, 30, 0)
                    },
                    Customer = new User
                    {
                        UserName = "Gosho",
                        FirstName = "Georgi",
                        LastName = "Georgiev",
                        UniqueCitizenNumber = "0123456789",
                        Email = "gosho@gosho.bg",
                        PasswordHash = "wqeqwdasfasfw"
                    }
                },
                new Order
                {
                    OrderedOn = new DateTime(2017, 10, 5, 20, 0, 0),
                    TicketCount = 10,
                    EventureEvent = new Event
                    {
                        Name = "New Years Eve",
                        PricePerTicket = 17.30m,
                        Place = "Lounge",
                        TotalTickets = 25,
                        Start = new DateTime(2017, 12, 31, 20, 0, 0),
                        End = new DateTime(2018, 1, 1, 5, 0, 0)
                    },
                    Customer = new User
                    {
                        UserName = "Vankata",
                        FirstName = "Ivan",
                        LastName = "Ivanov",
                        UniqueCitizenNumber = "9876543210",
                        Email = "vanko@vanko.bg",
                        PasswordHash = "hcjfgjdrthf"
                    }
                }
            };
        }
    }
}
