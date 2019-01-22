using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configurations
{
  public  class TeamEventConfiguration:IEntityTypeConfiguration<TeamEvent>
    {
        public void Configure(EntityTypeBuilder<TeamEvent> builder)
        {
            builder.HasKey(x => new {x.TeamId, x.EventId});

            builder
                .HasOne(x => x.Team)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Event)
                .WithMany(x => x.ParticipatingTeamEvents)
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
