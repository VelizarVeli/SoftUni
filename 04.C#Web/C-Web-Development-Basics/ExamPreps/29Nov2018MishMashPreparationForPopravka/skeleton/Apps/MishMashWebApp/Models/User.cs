using System.Collections.Generic;

namespace MishMashWebApp.Models
{
    public class User
    {
        public User()
        {
            this.FollowedChannels = new List<ChannelFollower>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public ICollection<ChannelFollower> FollowedChannels { get; set; }

        public UserRole Role { get; set; }
    }
}
