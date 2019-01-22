namespace Torshia.App.Data
{
    using Microsoft.EntityFrameworkCore;
    using Torshia.App.Data.EntityConfiguration;
    using Torshia.App.Models;

    public class TorshiaDbContext : DbContext
    {
        public TorshiaDbContext()
        {
        }

        public TorshiaDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<TaskSector> TaskSectors { get; set; }

        public DbSet<TaskParticitpant> TaskParticipants { get; set; }
        public User First { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=TorshiaDb;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration<Report>(new ReportConfiguration());

            modelBuilder
                .ApplyConfiguration<TaskSector>(new TaskSectorsConfiguration());

            modelBuilder
                .ApplyConfiguration<TaskParticitpant>(new TaskParticipantConfiguration());
        }
    }
}