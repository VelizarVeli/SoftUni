using System;

public class Owl : Bird
{
    private const double weightPerPiece = 0.25;

    public Owl(string name, double weigth, double wingSize)
        : base(name, weigth, wingSize)
    {
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

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }
}