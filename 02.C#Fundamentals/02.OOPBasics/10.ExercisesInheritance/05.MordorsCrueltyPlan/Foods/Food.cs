public abstract class Food
{
    public Food(int pointsOfHappiness)
    {
        this.PointsOfHappiness = pointsOfHappiness;
    }

    public int PointsOfHappiness { get; private set; }
}