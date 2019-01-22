using System;

namespace _02._1VaporStore
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            double initialBudget = budget;
            string game = Console.ReadLine();
            double currentPrice = 0;
            while (true)
            {
                if(game == "Game Time")
                {
                    break;
                }
                switch (game)
                {
                    case "OutFall 4":
                        currentPrice = 39.99;
                        break;
                    case "CS: OG":
                        currentPrice = 15.99;
                        break;
                    case "Zplinter Zell":
                        currentPrice = 19.99;
                        break;
                    case "Honored 2":
                        currentPrice = 59.99;
                        break;
                    case "RoverWatch":
                        currentPrice = 29.99;
                        break;
                    case "OutFRoverWatch Origins Edition":
                        currentPrice = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }
                if (currentPrice !=0)
                {
                    if (budget >= currentPrice)
                    {
                        Console.WriteLine("Bought " + game);
                        budget -= currentPrice;
                        currentPrice = 0;
                    }
                    if (currentPrice > budget)
                    {
                        Console.WriteLine("Too expensive");
                    }
                    if (budget <= 0)
                    {
                        Console.WriteLine("Out of money!");
                        return;
                    }
                    game = Console.ReadLine();
                }
                Console.WriteLine($"Total spent: ${(initialBudget - budget):f2}. Remaining: ${budget:f2}");
            }

        }
    }
}
