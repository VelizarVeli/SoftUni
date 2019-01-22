using Eventures.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Data
{
    public class EventuresDbContext : IdentityDbContext<EventuresUser>
    {
        public EventuresDbContext(DbContextOptions<EventuresDbContext> options)
            : base(options)
        {
        }
        public DbSet<EventuresUser> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
