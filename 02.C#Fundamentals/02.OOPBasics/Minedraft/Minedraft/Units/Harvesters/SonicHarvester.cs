using System;

public class SonicHarvester : Harvester
{
    public override string Type => "Sonic";

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor):
        base(id, oreOutput, energyRequirement)
    {
        EnergyRequirement = energyRequirement / sonicFactor;
    }
}