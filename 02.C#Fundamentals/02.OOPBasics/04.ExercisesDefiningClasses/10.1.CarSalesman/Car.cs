using System;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public double? Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
    }

    public Car(string model, Engine engine, double weight)
    : this(model, engine)
    {
        this.Weight = weight;
    }

    public Car(string model, Engine engine, double weight, string color)
    : this(model, engine, weight)
    {
        this.Color = color;
    }

    public Car(string model, Engine engine, string color)
    :this(model, engine)
    {
        this.Color = color;
    }

    public override string ToString()
    {
        var result = $"{this.Model}:";
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.Engine.ToString());
        result = string.Concat(result, this.Weight == null ? "  Weight: n/a" : $"  Weight: {this.Weight}");
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.Color == null ? "  Color: n/a" : $"  Color: {this.Color}");
        result = string.Concat(result, Environment.NewLine);

        return result;

    }
}