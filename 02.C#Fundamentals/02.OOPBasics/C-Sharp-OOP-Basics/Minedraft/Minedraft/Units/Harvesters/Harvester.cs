using System;

public abstract class Harvester : Unit
{
    private const double MAX_ENERGY_REQUIREMENT = 10000;
    private double oreOutput;
    private double energyRequirement;

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value >= MAX_ENERGY_REQUIREMENT)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            oreOutput = value;
        }
    }

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        EnergyRequirement = energyRequirement;
        OreOutput = oreOutput;
    }

    public override string ToString()
    {
        return $"{Type} Harvester - {Id}" + Environment.NewLine +
               $"Ore Output: {OreOutput}" + Environment.NewLine +
               $"Energy Requirement: {EnergyRequirement}";
    }
}