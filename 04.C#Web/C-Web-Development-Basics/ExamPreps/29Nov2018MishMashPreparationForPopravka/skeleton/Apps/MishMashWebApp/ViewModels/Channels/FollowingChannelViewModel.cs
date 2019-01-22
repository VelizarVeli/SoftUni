using System.Collections.Generic;

namespace MishMashWebApp.ViewModels.Channels
{
    public class FollowingChannelViewModel
    {
        public IEnumerable<BaseChannelViewModel> FollowedChannels { get; set; }
    }
}
