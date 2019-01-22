namespace IRunes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Track
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }
    }
}