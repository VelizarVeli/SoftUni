using Microsoft.EntityFrameworkCore;
using TORSHIAWebApp.Models;

namespace TORSHIAWebApp.Data
{
    public class TorshiaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<TaskSector> TaskSectors { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public TorshiaDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=TORSHIA;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .HasOne(u => u.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(fk => fk.UserId);

            modelBuilder.Entity<Participant>()
                .HasOne(u => u.Task)
                .WithMany(t => t.Participants)
                .HasForeignKey(fk => fk.TaskId);

            modelBuilder.Entity<Participant>()
                .HasKey(cc => new {cc.TaskId, cc.UserId});


        }
    }
}