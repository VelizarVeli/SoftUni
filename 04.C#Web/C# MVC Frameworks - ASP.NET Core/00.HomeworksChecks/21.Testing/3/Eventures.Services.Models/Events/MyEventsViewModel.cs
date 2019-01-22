using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Models.Events
{
    public class MyEventsViewModel
    {
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Tickets { get; set; }

        public string StartToStr => this.Start.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture);

        public string EndToStr => this.End.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture);
    }
}
