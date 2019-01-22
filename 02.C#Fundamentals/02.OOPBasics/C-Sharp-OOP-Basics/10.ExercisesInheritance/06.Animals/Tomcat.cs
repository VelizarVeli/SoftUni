public class Tomcat : Cat
{
    private const string Gender = "Male";

    public Tomcat(string name, int age) : base(name, age, Gender)
    {
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}