public abstract class Mammal : Animal, IMammal
{
    public Mammal(string name, double weigth, string livingRegion)
        : base(name, weigth)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; protected set; }
}