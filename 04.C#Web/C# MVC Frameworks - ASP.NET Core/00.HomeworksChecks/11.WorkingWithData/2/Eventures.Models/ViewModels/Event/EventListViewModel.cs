using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Models.ViewModels.Event
{
    public class EventListViewModel
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
