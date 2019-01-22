namespace MishMashWebApp.Models
{
   public class ChannelFollower
    {
        public int Id { get; set; }

        public int FollowerId { get; set; }
        public User Follower { get; set; }

        public int FollowedChannelId { get; set; }
        public Channel FollowedChannel { get; set; }
    }
}
