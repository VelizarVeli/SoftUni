using System;

public class Tiger : Feline
{
    private const double weightPerPiece = 1.00;

    public Tiger(string name, double weigth, string livingRegion, string breed)
        : base(name, weigth, livingRegion, breed)
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
        return "ROAR!!!";
    }
}