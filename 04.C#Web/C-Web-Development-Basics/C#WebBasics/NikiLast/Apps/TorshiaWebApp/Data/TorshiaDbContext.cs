using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.Data
{
    public class TorshiaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=Chushka;Integrated Security=True;");
        }
    }
}
