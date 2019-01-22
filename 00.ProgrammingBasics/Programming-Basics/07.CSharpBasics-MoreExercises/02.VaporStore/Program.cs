using System;

namespace _02.VaporStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string game = "";
            double spent = 0;

            while (budget >= 0)
            {
                bool outOfMoney = false;
                if (game == "Game Time")
                {
                    break;
                }
                if (budget == 0)
                {
                    break;
                }
                game = Console.ReadLine();
                switch (game)
                {
                    case "OutFall 4":
                        if (budget < 39.99)
                        {
                            outOfMoney = true;
                        }
                        else
                        {
                            budget -= 39.99;
                            spent += 39.99;
                        }
                        break;
                    case "CS: OG":
                        if (budget < 15.99)
                        {
                            outOfMoney = true;
                        }
                        else
                        {
                            budget -= 15.99;
                            spent += 15.99;
                        }
                        break;
                    case "Zplinter Zell":
                        if (budget < 19.99)
                        {
                            outOfMoney = true;
                        }
                        else
                        {
                            budget -= 19.99;
                            spent += 19.99;
                        }
                        break;
                    case "Honored 2":
                        if (budget < 59.99)
                        {
                            outOfMoney = true;
                        }
                        else
                        {
                            budget -= 59.99;
                            spent += 59.99;
                        }
                        break;
                    case "RoverWatch":
                        if (budget < 29.99)
                        {
                            outOfMoney = true;
                        }
                        else
                        {
                            budget -= 29.99;
                            spent += 29.99;
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        if (budget < 39.99)
                        {
                            outOfMoney = true;
                        }
                        else
                        {
                            budget -= 39.99;
                            spent += 39.99;
                        }
                        break;
                    case "Game Time":
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                if (outOfMoney == true)
                {

                    Console.WriteLine("Too Expensive");
                }
                else if (game == "OutFall 4" || game == "CS: OG" || game == "Zplinter Zell" || game == "Honored 2" || game == "RoverWatch" || game == "RoverWatch Origins Edition")
                {
                    Console.WriteLine($"Bought {game}");
                }
            }
            if (budget == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            Console.WriteLine($"Total spent: ${spent}. Remaining: ${Math.Round(budget, 2)}");
        }
    }
}
