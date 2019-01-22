using System;
using System.Linq;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
    : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (!value.All(char.IsLetterOrDigit) || value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        var result = $"First Name: {this.FirstName}" + Environment.NewLine
            + $"Last Name: {this.LastName}" + Environment.NewLine  + 
            $"Faculty number: {this.FacultyNumber}" + Environment.NewLine;
        return result;
    }
}