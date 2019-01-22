using System;
using System.ComponentModel.DataAnnotations;

namespace MyChushka.WebApp.ViewModels.Orders
{
    public class AllOrdersViewModel
    {
        public int Number { get; set; }

        public int Id { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ordered On")]
        public DateTime OrderedOn { get; set; }
    }
}