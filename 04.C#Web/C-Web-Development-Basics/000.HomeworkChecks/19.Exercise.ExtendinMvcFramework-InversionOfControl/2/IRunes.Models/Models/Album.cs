using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Models.Models
{
    public class Album : BaseModel<Guid>
    {
        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
