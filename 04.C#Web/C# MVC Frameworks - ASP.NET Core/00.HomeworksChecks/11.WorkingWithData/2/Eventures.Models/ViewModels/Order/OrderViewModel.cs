using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Models.ViewModels.Order
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public string Customer { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderedOn { get; set; }

    }
}
