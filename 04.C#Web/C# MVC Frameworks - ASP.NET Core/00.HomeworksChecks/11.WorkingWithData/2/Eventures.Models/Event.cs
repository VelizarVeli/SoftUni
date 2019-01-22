using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Tickets { get; set; }
        public decimal PricePerTicket { get; set; }
    }
}
