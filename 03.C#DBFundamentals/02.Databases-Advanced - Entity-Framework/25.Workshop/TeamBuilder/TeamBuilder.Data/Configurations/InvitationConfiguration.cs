using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configurations
{
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder
                .HasOne(x => x.Team)
                .WithMany(x => x.MemberInvitations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
