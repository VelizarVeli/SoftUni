public class Cymric : Cat
{
    public decimal FurLength { get; set; }

    public Cymric(string name, decimal furLength)
    {
        this.Name = name;
        this.FurLength = furLength;
    }

    public override string ToString()
    {
        return $"Cymric {this.Name} {this.FurLength:f2}";
    }
}