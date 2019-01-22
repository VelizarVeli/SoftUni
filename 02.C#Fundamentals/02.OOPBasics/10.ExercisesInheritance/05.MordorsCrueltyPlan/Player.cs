using System;
using System.Collections.Generic;

public class Player
{
    private int HappinessPoints { get; set; }

    public Mood GetMentalCondition()
    {
        return MoodFactory.GetMood(this.HappinessPoints);
    }

    internal void Eat(IEnumerable<Food> foods)
    {
        foreach (var food in foods)
        {
            this.HappinessPoints += food.PointsOfHappiness;
        }
    }

    public override string ToString()
    {
        var mood = this.GetMentalCondition();
        return $"{this.HappinessPoints}{Environment.NewLine}{mood.GetType().Name}";
    }
}