public class Siamese : Cat
{
    public decimal EarSize { get; set; }

    public Siamese(string name, decimal earSize)
    {
        this.Name = name;
        this.EarSize = earSize;
    }

    public override string ToString()
    {
        return $"Siamese {this.Name} {this.EarSize}";
    }
}