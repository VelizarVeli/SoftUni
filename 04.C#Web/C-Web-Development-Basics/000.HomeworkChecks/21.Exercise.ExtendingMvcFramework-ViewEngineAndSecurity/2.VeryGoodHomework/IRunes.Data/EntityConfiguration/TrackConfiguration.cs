using IRunes.Models;
using IRunes.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRunes.Data.EntityConfiguration
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
	public void Configure(EntityTypeBuilder<Track> entityBuilder)
	{
	    entityBuilder.HasKey(t => t.Id);

	    entityBuilder.Property(t => t.Artist)
		.IsRequired(true)
		.IsUnicode(true);

	    entityBuilder.Property(t => t.Title)
		.IsRequired(true)
		.IsUnicode(true);

	    entityBuilder.HasIndex(t => new { t.Artist, t.Title })
		.IsUnique(true);

	    entityBuilder.Property(t => t.Genre)
		.HasDefaultValue(MusicGenre.Unclassified);

	    entityBuilder.HasMany(t => t.TrackAlbums)
		.WithOne(ta => ta.Track)
		.HasForeignKey(ta => ta.TrackId);

	    entityBuilder.HasMany(t => t.TrackUsers)
		.WithOne(tu => tu.Track)
		.HasForeignKey(tu => tu.TrackId);
	}
    }
}
