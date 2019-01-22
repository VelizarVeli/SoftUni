using System.ComponentModel.DataAnnotations;

namespace Instagraph.Models
{
    public class UserFollower
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int FollowerId { get; set; }
        public User Follower { get; set; }
    }
}
