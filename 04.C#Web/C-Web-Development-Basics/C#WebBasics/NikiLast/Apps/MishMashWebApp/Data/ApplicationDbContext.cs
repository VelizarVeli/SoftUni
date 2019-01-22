using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Models;

namespace MishMashWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<UserInChannel> UserInChannel { get; set; }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=MishMash;Integrated Security=True;");
        }
    }
}
