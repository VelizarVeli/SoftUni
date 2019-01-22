using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        public DateGreaterThanAttribute(string dateToCompareToFieldName)
        {
            DateToCompareToFieldName = dateToCompareToFieldName;
        }

        private string DateToCompareToFieldName { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime earlierDate = (DateTime)value;

            DateTime laterDate = (DateTime)validationContext
                .ObjectType
                .GetProperty(DateToCompareToFieldName)
                .GetValue(validationContext
                .ObjectInstance, null);

            if (laterDate < earlierDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date should be in the future");
            }
        }
    }
}
