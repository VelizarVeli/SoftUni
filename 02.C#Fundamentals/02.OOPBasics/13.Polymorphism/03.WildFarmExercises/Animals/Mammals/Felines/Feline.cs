public abstract class Feline : Mammal, IFeline
{
    public Feline(string name, double weigth, string livingRegion, string breed)
        : base(name, weigth, livingRegion)
    {
        this.Breed = breed;
    }

    public string Breed { get; protected set; }

    public override string ToString()
    {
        return base.ToString()
               + $"{this.Breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
    }
}