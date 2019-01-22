namespace TrainSystem.App.Models
{
    using Microsoft.EntityFrameworkCore;

    public class TrainSystemDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public TrainSystemDbContext(DbContextOptions<TrainSystemDbContext> options) : base(options)
        {
            this.InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            this.Database.EnsureCreated();
        }
    }
}