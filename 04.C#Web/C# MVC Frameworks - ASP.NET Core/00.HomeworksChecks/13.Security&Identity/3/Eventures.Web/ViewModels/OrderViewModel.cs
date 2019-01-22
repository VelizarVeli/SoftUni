using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.ViewModels
{
    public class OrderViewModel
    {
        [DisplayName("Event")]
        public string EventName  { get; set; }

        [DisplayName("Customer")]
        public string Customer { get; set; }

        [DisplayName("Ordered On")]
        public DateTime CreatedOn { get; set; }
    }
}
