using IRunes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRunes.Data.EntityConfiguration
{
    public class AlbumTrackConfiguration : IEntityTypeConfiguration<AlbumTrack>
    {
	public void Configure(EntityTypeBuilder<AlbumTrack> entityBuilder)
	{
	    entityBuilder.HasKey(at => new { at.AlbumId, at.TrackId });

	    entityBuilder.HasOne(at => at.Album)
		.WithMany(a => a.AlbumTracks)
		.HasForeignKey(at => at.AlbumId)
		.OnDelete(DeleteBehavior.Cascade);

	    entityBuilder.HasOne(at => at.Track)
		.WithMany(t => t.TrackAlbums)
		.HasForeignKey(at => at.TrackId)
		.OnDelete(DeleteBehavior.Cascade);
	}
    }
}
