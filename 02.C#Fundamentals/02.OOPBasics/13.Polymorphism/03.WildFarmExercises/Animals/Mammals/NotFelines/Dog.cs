using System;

public class Dog : Mammal
{
    private const double weightPerPiece = 0.40;

    public Dog(string name, double weigth, string livingRegion)
        : base(name, weigth, livingRegion)
    {
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }

    public override void EatFood(string food, int quantity)
    {
        if (food.Equals("Meat"))
        {
            base.FoodEaten += quantity;
            base.Weight += quantity * weightPerPiece;
        }
        else
        {
            throw new ArgumentException($"{this.GetType()} does not eat {food}!");
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"{base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
    }
}