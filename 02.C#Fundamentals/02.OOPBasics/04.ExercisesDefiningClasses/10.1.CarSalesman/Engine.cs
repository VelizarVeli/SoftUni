using System;

public class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public double? Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string model, int power)
    {
        this.Model = model;
        this.Power = power;
    }

    public Engine(string model, int power, double displacement)
        :this(model, power)
    {
        this.Displacement = displacement;
    }

    public Engine(string model, int power, double displacement, string efficiency)
    :this(model, power, displacement)
    {
        this.Efficiency = efficiency;
    }

    public Engine(string model, int power, string efficiency)
    :this(model, power)
    {
        this.Efficiency = efficiency;
    }

    public override string ToString()
    {
        var result = $"  {this.Model}:";
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, $"    Power: {this.Power}");
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.Displacement == null ? "    Displacement: n/a" : $"    Displacement: {this.Displacement}");
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.Efficiency == null ? "    Efficiency: n/a" : $"    Efficiency: {this.Efficiency}");
        result = string.Concat(result, Environment.NewLine);

        return result;
    }
}