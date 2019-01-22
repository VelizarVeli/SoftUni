using System;

public class Mouse : Mammal
{
    private const double weightPerPiece = 0.10;

    public Mouse(string name, double weigth, string livingRegion)
        : base(name, weigth, livingRegion)
    {
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }

    public override void EatFood(string food, int quantity)
    {
        if (food.Equals("Vegetable") || food.Equals("Fruit"))
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