namespace WebServer.IRunesApplication.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Cover { get; set; }

        [Required]
        public decimal Price { get; set; }


        public List<Track> Tracks { get; set; } = new List<Track>();
    }
}
