using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIS.Framework.Attributes.Properties
{
    public class NumberRangeAttribute : ValidationAttribute
    {
        private readonly double minimumValue;

        private readonly double maximumValue;

        public NumberRangeAttribute(double minValue, double maxValue)
        {
            this.minimumValue = minValue;
            this.maximumValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return (double)value >= this.minimumValue && (double)value <= this.maximumValue;
        }
    }
}
