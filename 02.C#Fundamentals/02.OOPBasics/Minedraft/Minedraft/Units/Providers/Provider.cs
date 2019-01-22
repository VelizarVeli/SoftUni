using System;

public abstract class Provider : Unit
{
    private const double MAX_ENERGY_OUTPUT = 10000;
    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
        private set
        {
            if (value >= MAX_ENERGY_OUTPUT || value < 0)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }

    protected Provider(string id, double energyOutput):
        base(id)
    {
        EnergyOutput = energyOutput;
    }

    public override string ToString()
    {
        return $"{Type} Provider - {Id}" + Environment.NewLine +
               $"Energy Output: {EnergyOutput}";
    }
}