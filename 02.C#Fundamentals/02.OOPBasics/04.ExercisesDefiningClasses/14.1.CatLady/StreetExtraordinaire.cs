public class StreetExtraordinaire : Cat
{
    public decimal DecibelsOfMeows { get; set; }

    public StreetExtraordinaire(string name, decimal decibelsOfMeows)
    {
        this.Name = name;
        this.DecibelsOfMeows = decibelsOfMeows;
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.DecibelsOfMeows}";
    }
}