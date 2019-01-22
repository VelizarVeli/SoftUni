using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.ViewModels
{
    public class EventViewModel : IValidatableObject
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }
        
        
        public DateTime Start { get; set; }

        
        public DateTime End { get; set; }

        [DisplayName("Tickets")]
        [Range(0, int.MaxValue)]
        public int TicketsOrdered { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.End < this.Start)
            {
                yield return new ValidationResult("EndDate must be after StartDate");
            }
        }
    }
}
