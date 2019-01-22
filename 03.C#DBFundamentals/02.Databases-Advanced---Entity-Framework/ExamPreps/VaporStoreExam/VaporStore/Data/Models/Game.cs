using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
	public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int DeveloperId { get; set; }
        [Required]
        public Developer Developer { get; set; }

        public int GenreId { get; set; }
        [Required]
        public Genre Genre { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public ICollection<GameTag> GameTags { get; set; }
   // •	 - Each game must have at least one tag.
    }
}
