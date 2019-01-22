using System;

public class Worker : Human
{
    private decimal weekSalary;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
    : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    private decimal workHoursPerDay;

    public decimal WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }

    private  decimal CalculateHourSalary()
    {
        var salaryPerDay = this.weekSalary / 5;
        return salaryPerDay / this.workHoursPerDay;
    }

    public override string ToString()
    {
        var result = $"First Name: {this.FirstName}" + Environment.NewLine
                                                     + $"Last Name: {this.LastName}" + Environment.NewLine +
                                                     $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine +
                                                     $"Hours per day: {this.workHoursPerDay:f2}" + Environment.NewLine +
                                                     $"Salary per hour: {CalculateHourSalary():f2}" + Environment.NewLine;
        return result;
    }
}