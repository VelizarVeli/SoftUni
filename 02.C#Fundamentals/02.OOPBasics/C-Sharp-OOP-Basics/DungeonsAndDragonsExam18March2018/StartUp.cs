using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
		    string input;
            var dungeonMaster = new DungeonMaster();
		    while ((input = Console.ReadLine()) != "IsGameOver" || string.IsNullOrEmpty(input))
		    {
		        var arguments = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
		        var command = arguments[0];
		        switch (command)
		        {
                    case "JoinParty":
                        Console.WriteLine();
                        break;
                    case "AddItemToPool":
                        Console.WriteLine();
                        break;
		            case "PickUpItem":
		                Console.WriteLine();
		                break;
		            case "UseItem":
		                Console.WriteLine();
		                break;
		            case "UseItemOn":
		                Console.WriteLine();
		                break;
		            case "GiveCharacterItem":
		                Console.WriteLine();
		                break;
		            case "GetStats":
		                Console.WriteLine();
		                break;
		            case "Attack":
		                Console.WriteLine();
		                break;
		            case "Heal":
		                Console.WriteLine();
		                break;
		            case "EndTurn":
		                Console.WriteLine();
		                break;
                }
		    }
            Console.WriteLine();
		}
	}
}