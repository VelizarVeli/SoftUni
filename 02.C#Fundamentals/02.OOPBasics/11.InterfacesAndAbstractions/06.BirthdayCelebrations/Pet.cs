public class Pet : INamable, IBirthable
{
    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.BirthDate = birthdate;
    }

    public string BirthDate { get; private set; }

    public string Name { get; private set; }
}