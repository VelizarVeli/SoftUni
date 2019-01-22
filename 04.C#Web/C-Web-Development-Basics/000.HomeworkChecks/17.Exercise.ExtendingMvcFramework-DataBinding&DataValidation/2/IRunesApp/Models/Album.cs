namespace IRunesApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Album : BaseModel<string>
    {
        public Album()
        {
            this.Tracks = new HashSet<TrackAlbum>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price => Math.Round(this.Tracks.Select(ta => ta.Track).Sum(t => t.Price) * 0.87M, 2);

        public virtual ICollection<TrackAlbum> Tracks { get; set; }
    }
}