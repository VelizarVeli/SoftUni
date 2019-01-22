//using System.Collections.Generic;
//using System.Linq;

//public class Department
//{
//    public string DepartmentName { get; set; }
//    public decimal AverageSalary { get; set; }
//    public List<Employee> DepartmentEmployees { get; set; }

//    public Department(string name, decimal salary)
//    {
//        this.DepartmentName = name;
//        this.AverageSalary = salary;
//        this.DepartmentEmployees = new List<Employee>();
//    }

//    public decimal CalculateAverage()
//    {
//        return this.DepartmentEmployees.Select(e => e.Salary).Average();
//    }
//}
using System.Collections.Generic;
using System.Linq;

public class Department
{
    private List<Employee> employees;
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Employee> Employees
    {
        get { return employees; }
        set { employees = value; }
    }

    public Department(string name)
    {
        this.Employees = new List<Employee>();
        this.Name = name;
    }

    public decimal CalculateAverage()
    {
        return this.Employees.Select(e => e.Salary).Average();
    }

    public void AddEmployee(Employee employee)
    {
        this.Employees.Add(employee);
    }
}