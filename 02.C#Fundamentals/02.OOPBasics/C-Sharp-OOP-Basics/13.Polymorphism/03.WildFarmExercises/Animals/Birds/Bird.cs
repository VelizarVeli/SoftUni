public abstract class Bird : Animal, IBird
{
    public Bird(string name, double weigth, double wingSize)
        : base(name, weigth)
    {
        this.WingSize = wingSize;
    }

    public double WingSize { get; private set; }

    public override string ToString()
    {
        return base.ToString() + $"{this.WingSize}, {base.Weight}, {base.FoodEaten}]";
    }
}