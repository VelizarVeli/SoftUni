using System.ComponentModel.DataAnnotations;

namespace Instagraph.Models
{
  public  class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
