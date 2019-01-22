using Instagraph.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagraph.Data.EntityConfiguration
{
  public  class CommentConfig:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasOne(u => u.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.Restrict);

                builder
                .HasOne(u => u.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(fk => fk.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
