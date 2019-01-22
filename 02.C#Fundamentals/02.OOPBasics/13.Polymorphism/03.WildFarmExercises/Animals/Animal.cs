public abstract class Animal : IAnimal, ISoundProducable
{
    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public virtual string Name { get; protected set; }

    public virtual double Weight { get; protected set; }

    public virtual int FoodEaten { get; protected set; }

    public abstract string ProduceSound();

    public abstract void EatFood(string food, int quantity);

    public override string ToString()
    {
        return $"{this.GetType()} [{this.Name}, ";
    }
}