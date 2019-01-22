using Instagraph.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagraph.Data.EntityConfiguration
{
   public class PostConfig:IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {

           builder
                .HasOne(e => e.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Picture)
                .WithMany(p => p.Posts)
                .HasForeignKey(u => u.PictureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
