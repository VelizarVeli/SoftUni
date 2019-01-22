public class Rebel:IName,IAge, IBuyer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }
    private int food;

    public int Food
    {
        get { return food; }
        set { food = value; }
    }

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
        this.food = 0;
    }

    public void BuyFood()
    {
        this.food += 5;
    }

}