public class Threeuple<Т1, Т2, T3>
{
    public Threeuple(Т1 item1, Т2 item2, T3 item3)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        this.Item3 = item3;
    }

    public Т1 Item1 { get; private set; }

    public Т2 Item2 { get; private set; }

    public T3 Item3 { get; private set; }

    public override string ToString()
    {
        return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
    }
}