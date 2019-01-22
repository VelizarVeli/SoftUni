using Microsoft.EntityFrameworkCore;
using Relations.Models;

namespace Relations.Data
{
    public class RelationsDbContext : DbContext
    {
        public RelationsDbContext()
        {
        }

        public RelationsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentsCourses> StudentsCourseses { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsCourses>()
                .HasKey(sc => new {sc.CourseId, sc.StudentId});
        }
    }
}