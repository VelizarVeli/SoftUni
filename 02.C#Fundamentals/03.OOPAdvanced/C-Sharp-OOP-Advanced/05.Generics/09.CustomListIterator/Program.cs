using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        ICustomList<string> customList = new CustomList<string>();

        var command = Console.ReadLine();
        while (!command.Equals("END"))
        {
            ExecuteCommand(customList, command);
            command = Console.ReadLine();
        }
    }

    private static void ExecuteCommand(ICustomList<string> customList, string command)
    {
        var commandArgs = command.Split(' ');
        var commandName = commandArgs[0];
        var args = commandArgs.Skip(1).ToArray();

        switch (commandName)
        {
            case "Add":
                customList.Add(args[0]);
                break;
            case "Remove":
                customList.Remove(int.Parse(args[0]));
                break;
            case "Contains":
                Console.WriteLine(customList.Contains(args[0]));
                break;
            case "Swap":
                customList.Swap(int.Parse(args[0]), int.Parse(args[1]));
                break;
            case "Greater":
                Console.WriteLine(customList.CountGreaterThan(args[0]));
                break;
            case "Max":
                Console.WriteLine(customList.Max());
                break;
            case "Min":
                Console.WriteLine(customList.Min());
                break;
            case "Print":
                Console.WriteLine(customList);
                break;
            case "Sort":
                customList.Sort();
                break;
            default:
                break;
        }
    }
}