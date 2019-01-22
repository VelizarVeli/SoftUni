using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesWebApp.Models
{
    public class Track : BaseEntity<string>
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }

        public string AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
