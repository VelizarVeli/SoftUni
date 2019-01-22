public class Citizen : INational, IName, IBirthable, IAge, IBuyer
{
    public string Name { get; set; }
    private int age;
    public string Id { get; set; }
    public string Birthdate { get; set; }
    public int Food { get; set; }
    
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Id = id;
        this.Age = age;
        this.Birthdate = birthdate;
        this.Food = 0;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string id { get; set; }


    public void BuyFood()
    {
        this.Food += 10;
    }

}