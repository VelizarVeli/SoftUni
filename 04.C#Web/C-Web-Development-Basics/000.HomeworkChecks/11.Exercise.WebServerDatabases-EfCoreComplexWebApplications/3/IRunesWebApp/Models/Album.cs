namespace IRunesWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Album : BaseEntity<string>
    {
        public Album()
        {
            this.Tracks = new HashSet<TrackAlbum>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<TrackAlbum> Tracks { get; set; }
    }
}
