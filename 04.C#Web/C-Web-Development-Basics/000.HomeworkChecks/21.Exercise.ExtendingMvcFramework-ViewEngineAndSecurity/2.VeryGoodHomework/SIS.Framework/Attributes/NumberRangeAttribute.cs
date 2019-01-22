using System;
using System.ComponentModel.DataAnnotations;

namespace SIS.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NumberRangeAttribute : ValidationAttribute
    {
	private readonly double maxValue;
	private readonly double minValue;

	public NumberRangeAttribute(
	    double minValue = double.MinValue,
	    double maxValue = double.MaxValue)
	{
	    this.minValue = minValue;
	    this.maxValue = maxValue;
	}

	public override bool IsValid(object value)
	{
	    return (double)value >= minValue && (double)value <= maxValue;
	}
    }
}
