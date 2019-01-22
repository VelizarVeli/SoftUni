using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Models;

namespace MishMashWebApp.Data
{
    public class MishMashDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelFollower> ChannelFollowers { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ECROG0\SQLEXPRESS;Database=MishMash;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChannelFollower>()
                .HasOne(f => f.FollowedChannel)
                .WithMany(u => u.Followers)
                .HasForeignKey(fk => fk.FollowedChannelId);

            modelBuilder.Entity<ChannelFollower>()
                .HasOne(f => f.Follower)
                .WithMany(c => c.FollowedChannels)
                .HasForeignKey(fk => fk.FollowerId);

            modelBuilder.Entity<ChannelFollower>()
                .HasKey(cf => new { cf.FollowerId, cf.FollowedChannelId });

            modelBuilder.Entity<ChannelTag>()
                .HasOne(f => f.Channel)
                .WithMany(u => u.Tags)
                .HasForeignKey(fk => fk.ChannelId);

            modelBuilder.Entity<ChannelTag>()
                .HasOne(f => f.Tag)
                .WithMany(c => c.Channels)
                .HasForeignKey(fk => fk.TagId);

            modelBuilder.Entity<ChannelTag>()
                .HasKey(cf => new { cf.ChannelId, cf.TagId });
        }
    }
}
