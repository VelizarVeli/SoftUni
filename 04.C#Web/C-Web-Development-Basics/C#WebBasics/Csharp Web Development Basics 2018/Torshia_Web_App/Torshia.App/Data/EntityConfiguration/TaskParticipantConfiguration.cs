namespace Torshia.App.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Torshia.App.Models;

    public class TaskParticipantConfiguration : IEntityTypeConfiguration<TaskParticitpant>
    {
        public void Configure(EntityTypeBuilder<TaskParticitpant> builder)
        {
            builder
                .HasOne(tp => tp.Participant)
                .WithMany(p => p.Tasks)
                .HasForeignKey(tp => tp.ParticipantId);

            builder
                .HasOne(tp => tp.Task)
                .WithMany(t => t.Participants)
                .HasForeignKey(tp => tp.TaskId);

            builder
                .HasKey(tp => new { tp.TaskId, tp.ParticipantId });
        }
    }
}