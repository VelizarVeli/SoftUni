using Eventures.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.ViewModels.Orders
{
    public class CreateOrderBindingModel : IValidatableObject
    {
        public string EventId { get; set; }

        public int TotalTickets { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "TicketsCount")]
        public int TicketsCount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.TicketsCount > this.TotalTickets)
            {
                yield return new ValidationResult(string.Format(ErrorMessages.NotEnoughTickets, this.TotalTickets), new List<string> { "TicketsCount" });
            }
        }
    }
}
