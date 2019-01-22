using Eventures.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Eventures.Data
{
    public class EventuresDbContext : IdentityDbContext<User>
    {
        public EventuresDbContext(DbContextOptions<EventuresDbContext> options) 
            : base(options)
        {
        }

        public EventuresDbContext()
        {

        }

        public DbSet<Event> Eventd { get; set; }

       // public DbSet<CustomLog> Logs { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>()
                .Property(p => p.PricePerTicket)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(builder);
        }
    }
}
