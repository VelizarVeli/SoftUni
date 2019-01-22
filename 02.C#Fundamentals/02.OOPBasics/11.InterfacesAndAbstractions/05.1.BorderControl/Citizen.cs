public class Citizen : National
{
    private string name;
    private int age;

    public Citizen(string name, int age, string id)
        :base(id)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}