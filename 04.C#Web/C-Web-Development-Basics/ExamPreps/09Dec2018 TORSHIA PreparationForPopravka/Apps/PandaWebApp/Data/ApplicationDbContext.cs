using Microsoft.EntityFrameworkCore;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.Data
{
   public class ApplicationDbContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AffectedSector> AffectedSectors { get; set; }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=TORSHIA;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskParticipants>()
                .HasOne(t => t.Task)
                .WithMany(p => p.Participants)
                .HasForeignKey(t => t.TaskId);

            modelBuilder.Entity<TaskParticipants>()
                .HasOne(p => p.Participant)
                .WithMany(t => t.Tasks)
                .HasForeignKey(fk => fk.ParticipantId);

            modelBuilder.Entity<TaskParticipants>()
                .HasKey(ck => new {ck.Participant, ck.TaskId});
        }
    }
}
