using System;
using System.Globalization;

public class DateModifier
{
    public static decimal CalculateDaysBetween(string first, string second)
    {
        var firstDate = DateTime.ParseExact(first, "yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDate = DateTime.ParseExact(second, "yyyy MM dd", CultureInfo.InvariantCulture);

        if (secondDate < firstDate)
        {
            return CalculateDaysBetween(second, first);
        }
        return (secondDate - firstDate).Days;
    }
}