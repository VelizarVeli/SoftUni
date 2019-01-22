namespace Eventures.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class EventuresDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Event> Events { get; set; }

        public EventuresDbContext()
        {
        }

        public EventuresDbContext(DbContextOptions<EventuresDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>()
                .Property(e => e.TicketPrice)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(builder);
        }
    }
}
