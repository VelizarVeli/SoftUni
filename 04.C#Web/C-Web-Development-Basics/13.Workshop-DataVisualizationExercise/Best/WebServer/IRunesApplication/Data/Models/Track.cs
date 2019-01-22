namespace WebServer.IRunesApplication.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Track
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string VideoUrl { get; set; }

        public decimal Price { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
