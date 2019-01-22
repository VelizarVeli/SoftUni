namespace Google.App.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] input);
    }
}
