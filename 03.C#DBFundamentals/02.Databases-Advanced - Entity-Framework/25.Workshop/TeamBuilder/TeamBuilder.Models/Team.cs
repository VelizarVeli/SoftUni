using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamBuilder.Models
{
    public class Team
    {
        [Key]
        [MinLength(0)]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Description { get; set; }

        [StringLength(3)]
        [Required]
        public string Acronym { get; set; }

        [MinLength(0)]
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public virtual ICollection<UserTeam> Members{ get; set; } = new List<UserTeam>();
        public virtual ICollection<TeamEvent> Events{ get; set; } = new List<TeamEvent>();
        public virtual ICollection<Invitation> MemberInvitations { get; set; }
    }
}
