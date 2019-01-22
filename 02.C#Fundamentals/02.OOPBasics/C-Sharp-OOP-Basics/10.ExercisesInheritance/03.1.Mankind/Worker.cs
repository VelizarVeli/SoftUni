using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string secondName, decimal weekSalary, decimal workingHours)
    : base(firstName, secondName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workingHours;
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

    private decimal CalculateSalaryPerHour()
    {
        decimal result = WeekSalary / 5 / WorkHoursPerDay;

        return result;
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}" + Environment.NewLine +
               $"Last Name: {this.LastName}" + Environment.NewLine +
               $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine +
               $"Hours per day: {this.WorkHoursPerDay:f2}" + Environment.NewLine +
               $"Salary per hour: {CalculateSalaryPerHour():f2}";
    }
}