namespace Torshia.App.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Torshia.App.Models;

    public class TaskSectorsConfiguration : IEntityTypeConfiguration<TaskSector>
    {
        public void Configure(EntityTypeBuilder<TaskSector> builder)
        {
            builder
                .HasOne(ts => ts.Task)
                .WithMany(t => t.AffectedSectors)
                .HasForeignKey(ts => ts.TaskId);

            builder
                .HasOne(ts => ts.Sector)
                .WithMany(s => s.Tasks)
                .HasForeignKey(ts => ts.SectorId);

            builder
                .HasKey(ts => new { ts.TaskId, ts.SectorId });
        }
    }
}