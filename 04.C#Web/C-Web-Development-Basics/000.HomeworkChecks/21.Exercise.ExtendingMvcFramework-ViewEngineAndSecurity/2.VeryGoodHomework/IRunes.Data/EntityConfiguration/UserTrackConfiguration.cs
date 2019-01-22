using IRunes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRunes.Data.EntityConfiguration
{
    public class UserTrackConfiguration : IEntityTypeConfiguration<UserTrack>
    {
	public void Configure(EntityTypeBuilder<UserTrack> entityBuilder)
	{
	    entityBuilder.HasKey(ut => new { ut.UserId, ut.TrackId });

	    entityBuilder.HasOne(ut => ut.User)
		.WithMany(u => u.UserTracks)
		.HasForeignKey(ut => ut.UserId)
		.OnDelete(DeleteBehavior.Cascade);

	    entityBuilder.HasOne(ut => ut.Track)
		.WithMany(t => t.TrackUsers)
		.HasForeignKey(ut => ut.TrackId)
		.OnDelete(DeleteBehavior.Cascade);
	}
    }
}
