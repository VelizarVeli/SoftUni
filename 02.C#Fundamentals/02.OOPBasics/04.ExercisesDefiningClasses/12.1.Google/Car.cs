using System;

public class Car
{
    public string Model { get; set; }
    public int Speed { get; set; }

    public Car(string model, int speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    public override string ToString()
    {
        var result = string.Concat(Environment.NewLine);
        result = string.Concat(result, $"{this.Model} ");
        result = string.Concat(result, this.Speed == null ? "" : $"{this.Speed}");
        result = string.Concat(result, Environment.NewLine);

        return result;
    }
}