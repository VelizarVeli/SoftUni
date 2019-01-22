using System.Collections.Generic;

namespace MishMashWebApp.Models
{
    public class Channel
    {
        public Channel()
        {
            this.Followers = new List<ChannelFollower>();
            this.Tags = new List<ChannelTag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType ChannelType { get; set; }

        public ICollection<ChannelTag> Tags { get; set; }

        public ICollection<ChannelFollower> Followers { get; set; }
    }
}
