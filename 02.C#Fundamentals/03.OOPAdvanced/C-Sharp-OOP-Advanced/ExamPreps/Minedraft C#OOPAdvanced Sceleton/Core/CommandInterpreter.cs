using System.Collections.Generic;

public class CommandInterpreter : ICommandInterpreter
{
    public IHarvesterController HarvesterController { get; }
    public IProviderController ProviderController { get; }
    public string ProcessCommand(IList<string> args)
    {
        throw new System.NotImplementedException();
    }
}