using System;
using System.Collections.Generic;
using System.Text;
using EVENTURES.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EVENTURES.Data
{
    public class EventureDbContext : IdentityDbContext<EvUser>
    {
        public EventureDbContext(DbContextOptions<EventureDbContext> options)
            : base(options)
        {

        }

        public EventureDbContext()
            : base(new DbContextOptions<EventureDbContext>())
        {
            var dbContextOptions = new DbContextOptionsBuilder<EventureDbContext>();
            dbContextOptions.UseSqlServer("Server=DESKTOP-8ECROG0\\SQLEXPRESS;Database=EVENTURES;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<CustomLog> Logs { get; set; }
    }
}
