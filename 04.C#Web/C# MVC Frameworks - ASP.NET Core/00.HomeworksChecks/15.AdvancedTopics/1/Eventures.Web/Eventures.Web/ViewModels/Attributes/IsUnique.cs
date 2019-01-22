using Eventures.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Eventures.Web.ViewModels.Attributes
{
    /*
     * This attribute works with STRING type only!!!
     */

    public class IsUnique : ValidationAttribute
    {
        private string property;
        private EventuresDbContext db;

        public IsUnique(string propertyToValidate)
        {
            this.property = propertyToValidate;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.db = (EventuresDbContext)validationContext.GetService(typeof(EventuresDbContext));

            var propertyValues = this.db.Users.Select(u => u.GetType()
                                .GetProperty(this.property,
                                             BindingFlags.Instance |
                                             BindingFlags.Public | 
                                             BindingFlags.IgnoreCase)
                                .GetValue(u, null))
                                .Select(v => v.ToString())
                                .ToList();

            if (propertyValues.Any(v => v == (string)value))
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
