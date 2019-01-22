using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.EntityConfiguration
{
  public  class StudentConfig:IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(x => x.HomeworkSubmissions)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            builder.HasMany(x => x.CourseEnrollments)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired(false);
        }
    }
}
