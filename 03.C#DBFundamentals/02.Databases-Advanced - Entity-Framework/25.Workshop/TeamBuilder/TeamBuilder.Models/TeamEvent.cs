using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamBuilder.Models
{
  public  class TeamEvent
    {
        [ForeignKey("Team")]
        [MinLength(0)]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        [ForeignKey("Event")]
        [MinLength(0)]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
