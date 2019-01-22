public class Hen : Bird
{
    private const double weightPerPiece = 0.35;

    public Hen(string name, double weigth, double wingSize)
        : base(name, weigth, wingSize)
    {
    }

    public override void EatFood(string food, int quantity)
    {
        base.Weight += quantity * weightPerPiece;
        base.FoodEaten += quantity;
    }

    public override string ProduceSound()
    {
        return "Cluck";
    }
}