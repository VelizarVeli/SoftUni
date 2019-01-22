using System;

public class Company
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Company(string name, string department, decimal salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    public override string ToString()
    {
        var result = string.Concat(Environment.NewLine);
        result = string.Concat(result, $"{this.Name} ");
        result = string.Concat(result, this.Department == null ? "" : $"{this.Department} ");
        result = string.Concat(result, this.Salary == null ? "" : $"{this.Salary}");
        result = string.Concat(result, Environment.NewLine);

        return result;
    }
}