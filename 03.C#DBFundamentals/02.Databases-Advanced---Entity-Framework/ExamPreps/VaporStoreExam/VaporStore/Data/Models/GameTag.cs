using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class GameTag
    {
        public int GameId { get; set; }
        [Required]
        public Game Game { get; set; }

        public int TagId { get; set; }
        [Required]
        public Tag Tag { get; set; }
    }
}
