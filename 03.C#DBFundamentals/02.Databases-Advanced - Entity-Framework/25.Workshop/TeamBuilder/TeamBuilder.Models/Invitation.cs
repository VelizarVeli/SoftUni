using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamBuilder.Models
{
    public class Invitation
    {
        public Invitation()
        {
            this.IsActive = true;
        }

        [Key]
        [MinLength(0)]
        public int Id { get; set; }

        [MinLength(0)]
        [ForeignKey("InviteUser")]
        public int InvitedUserId { get; set; }
        public virtual User InvitedUser { get; set; }

        [MinLength(0)]
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public bool IsActive { get; set; }
    }
}
