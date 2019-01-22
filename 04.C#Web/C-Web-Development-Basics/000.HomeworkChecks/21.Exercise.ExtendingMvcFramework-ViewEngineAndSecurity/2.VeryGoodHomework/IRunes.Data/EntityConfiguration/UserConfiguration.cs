using IRunes.Data.Common;
using IRunes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRunes.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
	public void Configure(EntityTypeBuilder<User> entityBuilder)
	{
	    entityBuilder.HasKey(u => u.Id);

	    entityBuilder.Property(u => u.Username)
		.IsRequired(true)
		.IsUnicode(false)
		.HasMaxLength(Constants.UsernameMaxLength);

	    entityBuilder.HasIndex(u => u.Username)
		.IsUnique(true);

	    entityBuilder.Property(u => u.Password)
		.IsRequired(true)
		.IsUnicode(false);

	    entityBuilder.Property(u => u.Email)
		.IsRequired(true)
		.IsUnicode(false);

	    entityBuilder.Property(u => u.FirstName)
		.IsUnicode(true);

	    entityBuilder.Property(u => u.LastName)
		.IsUnicode(true);

	    entityBuilder.HasMany(u => u.UserAlbums)
		.WithOne(ua => ua.User)
		.HasForeignKey(ua => ua.UserId);

	    entityBuilder.HasMany(u => u.UserTracks)
		.WithOne(ut => ut.User)
		.HasForeignKey(ut => ut.UserId);
	}
    }
}
