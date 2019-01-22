public interface IAnimal
{
    string Name { get; }

    double Weight { get; }

    int FoodEaten { get; }

    void EatFood(string food, int quantity);
}