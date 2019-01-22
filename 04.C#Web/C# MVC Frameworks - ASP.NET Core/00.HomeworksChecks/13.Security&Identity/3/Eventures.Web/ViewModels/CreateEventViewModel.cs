using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.ViewModels
{
    public class CreateEventViewModel : IValidatableObject
    {
        [Required]
        [DisplayName("Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Place")]
        [MaxLength(100)]
        public string Place { get; set; }

        [Required]
        [DisplayName("Start")]
        public DateTime Start { get; set; }

        [Required]
        [DisplayName("End")]
        public DateTime End { get; set; }

        [Required]
        [DisplayName("TotalTickets")]
        [Range(0, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        [DisplayName("PricePerTicket")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal PricePerTicket { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.End < this.Start)
            {
                yield return new ValidationResult("EndDate must be after StartDate");
            }
        }
    }
}
