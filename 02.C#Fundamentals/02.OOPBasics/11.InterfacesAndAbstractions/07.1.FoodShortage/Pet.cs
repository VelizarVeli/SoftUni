public class Pet : IName, IBirthable
{
    public string Name { get; set; }

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Birthdate { get; set; }
    public void BuyFood()
    {
        throw new System.NotImplementedException();
    }

    public int Food { get; set; }
}