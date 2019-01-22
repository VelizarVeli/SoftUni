using Eventures.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.ViewModels.Events
{
    public class CreateEventBindingModel : IValidatableObject
    {
        [Required]
        [Display(Name = "Name")]
        [MinLength(10, ErrorMessage = ErrorMessages.EventNameLenght)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Place")]
        [RegularExpression(@"^[A-Z][a-zA-Z]+,[ ]?[A-Z][a-zA-Z].*$", ErrorMessage = "Invalid City and Country Format")]
        public string Place { get; set; }

        [Required]
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{dd-MMM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [Required]
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{dd-MMM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }

        [Required]
        [Display(Name = "TotalTickets")]
        [Range(1, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        [Display(Name = "PricePerTicket")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal TicketPrice { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Start <= DateTime.Now)
            {
                yield return new ValidationResult(ErrorMessages.StartDateEarlierThanToday, new List<string> { "Start"});
            }

            if (this.End <= this.Start)
            {
                yield return new ValidationResult(ErrorMessages.EndDateLaterThanStartDate, new List<string> { "End" });
            }
        }
    }
}
