using IRunes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRunes.Data.EntityConfiguration
{
    public class UserAlbumConfiguration : IEntityTypeConfiguration<UserAlbum>
    {
	public void Configure(EntityTypeBuilder<UserAlbum> entityBuilder)
	{
	    entityBuilder.HasKey(ua => new { ua.UserId, ua.AlbumId });

	    entityBuilder.HasOne(ua => ua.User)
		.WithMany(u => u.UserAlbums)
		.HasForeignKey(ua => ua.UserId)
		.OnDelete(DeleteBehavior.Cascade);

	    entityBuilder.HasOne(ua => ua.Album)
		.WithMany(a => a.AlbumUsers)
		.HasForeignKey(ua => ua.AlbumId)
		.OnDelete(DeleteBehavior.Cascade);
	}
    }
}
