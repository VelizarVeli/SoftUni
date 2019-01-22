using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateGreaterAttribute : ValidationAttribute
    {
        public DateGreaterAttribute(string dateToCompareToFieldName)
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
                return new ValidationResult("The end of the event should be after the beginning");
            }
        }
    }
}
