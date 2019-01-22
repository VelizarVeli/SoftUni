namespace SIS.Models
{
    using System;
    using System.Collections.Generic;

    public class Track : BaseModel<string>
    {
        private decimal price;

        public Track()
        {
            this.Albums = new HashSet<TrackAlbum>();
        }

        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price
        {
            get => Math.Round(this.price, 2);
            set => this.price = value;
        }

        public virtual ICollection<TrackAlbum> Albums { get; set; }
    }
}