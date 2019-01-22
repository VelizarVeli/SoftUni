public class Ferrari:ICar
{
    public string Driver { get; private set; }
    public string Model
    {
        get => "488-Spider";
    }
    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        string answer = $"{Model}/{Brakes()}/{Gas()}/{Driver}";
        return answer;
    }
}