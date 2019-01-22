public class Cymric : Cat
{
    private double furLength;

    public Cymric(string name, double furLength)
    {
        this.Name = name;
        this.FurLength = furLength;
    }

    public double FurLength
    {
        get { return furLength; }
        set { furLength = value; }
    }

    public override string ToString()
    {
        return $"Cymric {this.Name} {this.FurLength:F2}";
    }
}