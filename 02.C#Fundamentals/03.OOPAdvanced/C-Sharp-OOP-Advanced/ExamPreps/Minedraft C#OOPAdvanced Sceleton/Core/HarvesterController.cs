using System.Collections.Generic;

public class HarvesterController : IHarvesterController
{
    public string Register(IList<string> args)
    {
        throw new System.NotImplementedException();
    }

    public string Produce()
    {
        throw new System.NotImplementedException();
    }

    public double OreProduced { get; }
    public string ChangeMode(string mode)
    {
        throw new System.NotImplementedException();
    }
}