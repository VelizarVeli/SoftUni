public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string email = "n/a";
    private int age = -1;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }


    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}