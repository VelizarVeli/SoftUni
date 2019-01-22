public class Tuple<Т1, Т2>
{
    public Tuple(Т1 item1, Т2 item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public Т1 Item1 { get; private set; }

    public Т2 Item2 { get; private set; }

    public override string ToString()
    {
        return $"{this.Item1} -> {this.Item2}";
    }
}