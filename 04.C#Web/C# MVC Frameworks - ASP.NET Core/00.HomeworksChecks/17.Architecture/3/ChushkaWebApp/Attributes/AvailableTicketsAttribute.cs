namespace EventWebApp.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class AvailableTicketsAttribute : ValidationAttribute
    {
        private readonly string tickets;

        public AvailableTicketsAttribute(string tickets)
        {
            this.tickets = tickets;
        }

        protected override ValidationResult IsValid(object totalTickets, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(this.tickets);
            var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
            return (int)totalTickets >= (int)propertyValue ? ValidationResult.Success : new ValidationResult("Tickets count bought must be same or less then tickets left");

        }
    }
}
