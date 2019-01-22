using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunesWebApp.Models
{
    public class Album : BaseEntity<string>
    {
        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }

        public string  Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
