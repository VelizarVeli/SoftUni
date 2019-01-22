using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new List<Team>();
            this.SecondaryKitTeams = new List<Team>();
        }

        [Key]
        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Team> PrimaryKitTeams { get; set; }

        public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
