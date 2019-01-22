using Instagraph.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagraph.Data
{
  public  class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .HasAlternateKey(e => e.Username);

            builder
                .HasOne(e => e.ProfilePicture)
                .WithMany(u => u.Users)
                .HasForeignKey(p => p.ProfilePictureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
