using Instagraph.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagraph.Data.EntityConfiguration
{
  public  class UserFollowerConfig:IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder
                .HasKey(uf => new { uf.FollowerId, uf.UserId });

            builder
                .HasOne(e => e.User)
                .WithMany(f => f.Followers)
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Follower)
                .WithMany(f => f.UsersFollowing)
                .HasForeignKey(fk => fk.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
