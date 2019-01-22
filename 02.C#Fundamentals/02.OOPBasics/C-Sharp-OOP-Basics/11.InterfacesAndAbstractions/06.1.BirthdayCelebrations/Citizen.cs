public class Citizen : INational, IName, IBirthable
{
    private int age;
    public string Name { get; set; }
    public string Birthdate { get; set; }
    
    public Citizen(string name, int age, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Birthdate = birthdate;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string id { get; set; }
}