using System;
using System.Globalization;

public class DateModifier
{
    public string StartDate { get; }
    public string EndDate { get; }

    public DateModifier(string startDate, string endDate)
    {
        this.StartDate = startDate;
        this.EndDate = endDate;
    }

    public int CalculateDateDifference(string startDat, string endDat)
    {
        DateTime startDate = (DateTime.ParseExact(StartDate, "yyyy MM dd", CultureInfo.InvariantCulture));
        DateTime endDate = (DateTime.ParseExact(EndDate, "yyyy MM dd", CultureInfo.InvariantCulture));
        int totalDays = (endDate - startDate).Days;
        return Math.Abs(totalDays);
    }
}