using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        switch (type)
        {
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            case "Sonic":
                return new SonicHarvester(id,oreOutput,energyRequirement,int.Parse(arguments[4]));
            default:
                throw new ArgumentException();
        }
    }
}